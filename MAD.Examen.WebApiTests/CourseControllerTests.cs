using FluentAssertions;
using MAD.Examen.Mocked;
using MAD.Examen.Models;
using MAD.Examen.UnitOfWork;
using MAD.Examen.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace MAD.Examen.WebApiTests
{
    public class CourseControllerTests
    {
        private readonly CourseController _courseController;
        private readonly IUnitOfWork _unitMocked;


        public CourseControllerTests()
        {
            var unitMocked = new CourseMocked();
            _unitMocked = unitMocked.GetInstance();
            _courseController = new CourseController(_unitMocked);

        }

        [Fact(DisplayName = "[CourseController] Get List")]
        public void Test_Get_All()
        {

            var result = _courseController.GetList() as OkObjectResult;


            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Course>;
            model.Count.Should().BeGreaterThan(0);

        }

        [Fact(DisplayName = "[CourseController] Insert")]
        public void Insert_Course_Test()
        {


            var course = new Course
            {
                CourseID = 1,
                Title = "Course",
                Credits = 100,
                DepartmentID = 10
            };

            var result = _courseController.Post(course) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(1);

        }




        [Fact(DisplayName = "[CourseController] Update")]
        public void Update_Course_Test()
        {
            var course = new Course
            {
                CourseID = 1,
                Title = "Course",
                Credits = 100,
                DepartmentID = 10
            };


            var result = _courseController.Put(course) as OkObjectResult;


            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();


            var model = result.Value?.GetType().GetProperty("Message").GetValue(result.Value);

            model.Should().Be("The course is updated");

            var currentCourse = _unitMocked.Courses.GetById(1);
            currentCourse.Should().NotBeNull();
            currentCourse.CourseID.Should().Be(course.CourseID);         
            currentCourse.Title.Should().Be(course.Title);
            currentCourse.Credits.Should().Be(course.Credits);
            currentCourse.DepartmentID.Should().Be(course.DepartmentID);


        }


        [Fact(DisplayName = "[CourseController] Update Error")]
        public void Update_Error_Course_Test()
        {
            var course = new Course
            {
                CourseID = 1,
                Title = "Course",
                Credits = 100,
                DepartmentID = 10
            };


            var result = _courseController.Put(course) as BadRequestObjectResult;

            result.Should().Equals(400);

        }


        [Fact(DisplayName = "[CourseController] Delete")]
        public void Delete_Course_Test()
        {

            var course = new Course
            {
                CourseID = 1
            };

            var result = _courseController.Delete(course) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

        }


        [Fact(DisplayName = "[CourseController] Delete Error")]
        public void Delete_Error_Course_Test()
        {

            var course = new Course
            {
                CourseID = 1
            };

            var result = _courseController.Delete(course) as BadRequestObjectResult;

            result.Should().Equals(400);

        }


        [Fact(DisplayName = "[CourseController] Get By Id")]
        public void GetById_Course_Test()
        {

            var result = _courseController.GetById(1) as OkObjectResult;

            result.Should().NotBeNull();

            result.Value.Should().NotBeNull();

            var model = result.Value as Course;
            model.Should().NotBeNull();
            model.CourseID.Should().BeGreaterThan(0);


        }

    }
}
