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
    public class PersonControllerTests
    {
        private readonly PersonController _personController;
        private readonly IUnitOfWork _unitMocked;


        public PersonControllerTests()
        {
            var unitMocked = new UnitOfWorkMocked();
            _unitMocked = unitMocked.GetInstance();
            _personController = new PersonController(_unitMocked);

        }

        [Fact(DisplayName = "[PersonController] Get List")]
        public void Test_Get_All()
        {

            var result = _personController.GetList() as OkObjectResult;


            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = result.Value as List<Person>;
            model.Count.Should().BeGreaterThan(0);

        }

        [Fact(DisplayName = "[PersonController] Insert")]
        public void Insert_Person_Test()
        {


            var person = new Person
            {
                PersonID = -100,
                FirstName = "Manuel",
                LastName = "Angeles",
                HireDate = DateTime.Now
            };

            var result = _personController.Post(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToInt32(result.Value);
            model.Should().Be(101);

        }

        


        [Fact(DisplayName = "[PersonController] Update Error")]
        public void Update_Error_Person_Test()
        {
            var person = new Person
            {
                PersonID = -100,
                FirstName = "Manuel",
                LastName = "Angeles",
                HireDate = DateTime.Now
            };


            var result = _personController.Put(person) as BadRequestObjectResult;

            result.Should().Equals(400);

        }


        [Fact(DisplayName = "[PersonController] Delete")]
        public void Delete_Person_Test()
        {

            var person = new Person
            {
                PersonID = 1
            };

            var result = _personController.Delete(person) as OkObjectResult;

            result.Should().NotBeNull();
            result.Value.Should().NotBeNull();

            var model = Convert.ToBoolean(result.Value);
            model.Should().BeTrue();

        }


        [Fact(DisplayName = "[PersonController] Delete Error")]
        public void Delete_Error_Person_Test()
        {

            var person = new Person
            {
                PersonID = -100
            };

            var result = _personController.Delete(person) as BadRequestObjectResult;

            result.Should().Equals(400);

        }


        [Fact(DisplayName = "[PersonController] Get By Id")]
        public void GetById_Csutomer_Test()
        {

            var result = _personController.GetById(1) as OkObjectResult;

            result.Should().NotBeNull();

            result.Value.Should().NotBeNull();

            var model = result.Value as Person;
            model.Should().NotBeNull();
            model.PersonID.Should().BeGreaterThan(0);


        }

    }
}
