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
    public class StudentGradeControllerTests
    {
        private readonly StudentGradeController _studentGradeController;
        private readonly IUnitOfWork _unitMocked;


        public StudentGradeControllerTests()
        {
            var unitMocked = new StudentGradeMocked();
            _unitMocked = unitMocked.GetInstance();
            _studentGradeController = new StudentGradeController(_unitMocked);

        }

        [Fact(DisplayName = "[StudentGradeController] Get List")]
        public void Test_Get_All()
        {

            var result = _studentGradeController.GetList() as OkObjectResult;


            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<StudentGrade>;
            model.Count.Should().BeGreaterThan(0);

        }

        [Fact(DisplayName = "[StudentGradeController] Insert")]
        public void Insert_StudentGrade_Test()
        {


            var studentGrade = new StudentGrade
            {
                EnrollmentID = 101,
                CourseID = 1,
                StudentID = 2,
                Grade = 10
            };

            var result = _studentGradeController.Post(studentGrade) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(101);

        }




        [Fact(DisplayName = "[StudentGradeController] Update")]
        public void Update_StudentGrade_Test()
        {

            var studentGrade = new StudentGrade
            {
                EnrollmentID = 101,
                CourseID = 1,
                StudentID = 2,
                Grade = 10
            };


            var result = _studentGradeController.Put(studentGrade) as OkObjectResult;


            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();


            var model = result.Value?.GetType().GetProperty("Message").GetValue(result.Value);

            model.Should().Be("The studentGrade is updated");

            var currentStudentGrade = _unitMocked.StudentGrades.GetById(101);
            currentStudentGrade.Should().NotBeNull();
            currentStudentGrade.EnrollmentID.Should().Be(studentGrade.EnrollmentID);         
            currentStudentGrade.CourseID.Should().Be(studentGrade.CourseID);
            currentStudentGrade.StudentID.Should().Be(studentGrade.StudentID);
            currentStudentGrade.Grade.Should().Be(studentGrade.Grade);


        }


        [Fact(DisplayName = "[StudentGradeController] Update Error")]
        public void Update_Error_StudentGrade_Test()
        {
            var studentGrade = new StudentGrade
            {
                EnrollmentID = 101,
                CourseID = 1,
                StudentID = 2,
                Grade = 10
            };


            var result = _studentGradeController.Put(studentGrade) as BadRequestObjectResult;

            result.Should().Equals(400);

        }


        [Fact(DisplayName = "[StudentGradeController] Delete")]
        public void Delete_StudentGrade_Test()
        {

            var studentGrade = new StudentGrade
            {
                EnrollmentID = 1
            };

            var result = _studentGradeController.Delete(studentGrade) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

        }


        [Fact(DisplayName = "[StudentGradeController] Delete Error")]
        public void Delete_Error_StudentGrade_Test()
        {

            var studentGrade = new StudentGrade
            {
                EnrollmentID = 1
            };

            var result = _studentGradeController.Delete(studentGrade) as BadRequestObjectResult;

            result.Should().Equals(400);

        }


        [Fact(DisplayName = "[StudentGradeController] Get By Id")]
        public void GetById_StudentGrade_Test()
        {

            var result = _studentGradeController.GetById(1) as OkObjectResult;

            result.Should().NotBeNull();

            result.Value.Should().NotBeNull();

            var model = result.Value as StudentGrade;
            model.Should().NotBeNull();
            model.EnrollmentID.Should().BeGreaterThan(0);


        }

    }
}
