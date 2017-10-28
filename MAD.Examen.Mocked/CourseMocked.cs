using AutoFixture;
using MAD.Examen.Models;
using MAD.Examen.Repositories.School;
using MAD.Examen.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAD.Examen.Mocked
{
    public class CourseMocked
    {
        
        private List<Course> _courses;

        public CourseMocked()
        {
            _courses = Courses();
        }

        private List<Course> Courses()
        {
            var fixture = new Fixture();
            var courses = fixture.CreateMany<Course>(50).ToList();

            for (int i = 0; i < 50; i++)
            {
                courses[i].CourseID = i + 1;
            }

            return courses;
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Courses).Returns(CourseRepositoryMocked());
            return mocked.Object;

        }

        private ICourseRepository CourseRepositoryMocked()
        {
            var courseMocked = new Mock<ICourseRepository>();
            courseMocked.Setup(c => c.GetList()).Returns(_courses);
            courseMocked.Setup(c => c.Insert(It.IsAny<Course>())).Callback<Course>((c) =>
               _courses.Add(c)).Returns<Course>(c => c.CourseID);

            courseMocked.Setup(c => c.Update(It.IsAny<Course>())).Callback<Course>((c) =>
            {
                _courses.RemoveAll(cour => cour.CourseID == c.CourseID);
                _courses.Add(c);
            }).Returns(true);

            courseMocked.Setup(c => c.Delete(It.IsAny<Course>())).Callback<Course>((c) => _courses.RemoveAll(cour => cour.CourseID == c.CourseID)).Returns(true);
            courseMocked.Setup(c => c.GetById(It.IsAny<int>())).Returns((int id) => _courses.FirstOrDefault(cour => cour.CourseID == id));

            return courseMocked.Object;
        }









    }
}
