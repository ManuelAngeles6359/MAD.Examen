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
    public class DepartmentControllerTests
    {
        private readonly DepartmentController _departmentController;
        private readonly IUnitOfWork _unitMocked;


        public DepartmentControllerTests()
        {
            var unitMocked = new DepartmentMocked();
            _unitMocked = unitMocked.GetInstance();
            _departmentController = new DepartmentController(_unitMocked);

        }

        [Fact(DisplayName = "[DepartmentController] Get List")]
        public void Test_Get_All()
        {

            var result = _departmentController.GetList() as OkObjectResult;


            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Department>;
            model.Count.Should().BeGreaterThan(0);

        }

        [Fact(DisplayName = "[DepartmentController] Insert")]
        public void Insert_Department_Test()
        {


            var department = new Department
            {
                DepartmentID = 1,
                Name = "Department",
                Budget = 100,
                StartDate = DateTime.Now,
                Administrator = 1

            };

            var result = _departmentController.Post(department) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(1);

        }




        [Fact(DisplayName = "[DepartmentController] Update")]
        public void Update_Department_Test()
        {

            var department = new Department
            {
                DepartmentID = 1,
                Name = "Department",
                Budget = 100,
                StartDate = DateTime.Now,
                Administrator = 1

            };

            var result = _departmentController.Put(department) as OkObjectResult;


            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();


            var model = result.Value?.GetType().GetProperty("Message").GetValue(result.Value);

            model.Should().Be("The department is updated");

            var currentDepartment = _unitMocked.Departments.GetById(1);
            currentDepartment.Should().NotBeNull();
            currentDepartment.DepartmentID.Should().Be(department.DepartmentID);         
            currentDepartment.Name.Should().Be(department.Name);
            currentDepartment.Budget.Should().Be(department.Budget);
            currentDepartment.StartDate.Should().Be(department.StartDate);
            currentDepartment.Administrator.Should().Be(department.Administrator);


        }


        [Fact(DisplayName = "[DepartmentController] Update Error")]
        public void Update_Error_Department_Test()
        {
            var department = new Department
            {
                DepartmentID = 1,
                Name = "Department",
                Budget = 100,
                StartDate = DateTime.Now,
                Administrator = 1

            };



            var result = _departmentController.Put(department) as BadRequestObjectResult;

            result.Should().Equals(400);

        }


        [Fact(DisplayName = "[DepartmentController] Delete")]
        public void Delete_Department_Test()
        {

            var department = new Department
            {
                DepartmentID = 1
            };

            var result = _departmentController.Delete(department) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

        }


        [Fact(DisplayName = "[DepartmentController] Delete Error")]
        public void Delete_Error_Department_Test()
        {

            var department = new Department
            {
                DepartmentID = 1
            };

            var result = _departmentController.Delete(department) as BadRequestObjectResult;

            result.Should().Equals(400);

        }


        [Fact(DisplayName = "[DepartmentController] Get By Id")]
        public void GetById_Department_Test()
        {

            var result = _departmentController.GetById(1) as OkObjectResult;

            result.Should().NotBeNull();

            result.Value.Should().NotBeNull();

            var model = result.Value as Department;
            model.Should().NotBeNull();
            model.DepartmentID.Should().BeGreaterThan(0);


        }

    }
}
