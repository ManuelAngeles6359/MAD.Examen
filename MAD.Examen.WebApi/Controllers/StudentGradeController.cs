using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAD.Examen.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Examen.Models;

namespace MAD.Examen.WebApi.Controllers
{
    public class StudentGradeController : BaseController
    {
        public StudentGradeController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.StudentGrades.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.StudentGrades.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] StudentGrade studentGrade)
        {
            if (ModelState.IsValid)
                return Ok(_unit.StudentGrades.Insert(studentGrade));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] StudentGrade studentGrade)
        {
            if (ModelState.IsValid && _unit.StudentGrades.Update(studentGrade) && studentGrade.EnrollmentID > 0)
                return Ok(new { Message = "The studentGrade is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] StudentGrade studentGrade)
        {
            if (studentGrade.EnrollmentID > 0)
                return Ok(_unit.StudentGrades.Delete(studentGrade));
            return BadRequest(new { Message = "Incorrect data." });
        }




    }
}