using AutoFixture;
using MAD.Examen.Models;
using MAD.Examen.Repositories.Dapper.School;
using MAD.Examen.Repositories.School;
using MAD.Examen.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAD.Examen.Mocked
{
    public class StudentGradeMocked
    {


        private List<StudentGrade> _studentGrades;

        public StudentGradeMocked()
        {
            _studentGrades = StudentGrades();
        }

        private List<StudentGrade> StudentGrades()
        {
            var fixture = new Fixture();
            var studentGrades = fixture.CreateMany<StudentGrade>(50).ToList();

            for (int i = 0; i < 50; i++)
            {
                studentGrades[i].EnrollmentID = i + 1;
            }

            return studentGrades;
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.StudentGrades).Returns(StudentGradeRepositoryMocked());
            return mocked.Object;

        }

        private IStudentGradeRepository StudentGradeRepositoryMocked()
        {
            var studentGradeMocked = new Mock<IStudentGradeRepository>();
            studentGradeMocked.Setup(c => c.GetList()).Returns(_studentGrades);
            studentGradeMocked.Setup(c => c.Insert(It.IsAny<StudentGrade>())).Callback<StudentGrade>((c) =>
               _studentGrades.Add(c)).Returns<StudentGrade>(c => c.EnrollmentID);

            studentGradeMocked.Setup(c => c.Update(It.IsAny<StudentGrade>())).Callback<StudentGrade>((c) =>
            {
                _studentGrades.RemoveAll(stuGrade => stuGrade.EnrollmentID == c.EnrollmentID);
                _studentGrades.Add(c);
            }).Returns(true);

            studentGradeMocked.Setup(c => c.Delete(It.IsAny<StudentGrade>())).Callback<StudentGrade>((c) => _studentGrades.RemoveAll(pers => pers.EnrollmentID == c.EnrollmentID)).Returns(true);
            studentGradeMocked.Setup(c => c.GetById(It.IsAny<int>())).Returns((int id) => _studentGrades.FirstOrDefault(pers => pers.EnrollmentID == id));

            return studentGradeMocked.Object;
        }










    }
}
