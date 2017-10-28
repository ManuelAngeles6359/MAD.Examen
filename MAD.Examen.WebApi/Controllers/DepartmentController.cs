using MAD.Examen.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Examen.Models;

namespace MAD.Examen.WebApi.Controllers
{

    [Route("api/Department")]
    public class DepartmentController : BaseController
    {
        public DepartmentController(IUnitOfWork unit) : base(unit)
        {
        }


        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Departments.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Departments.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Departments.Insert(department));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Department department)
        {
            if (ModelState.IsValid && _unit.Departments.Update(department) && department.DepartmentID > 0)
                return Ok(new { Message = "The department is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Department department)
        {
            if (department.DepartmentID > 0)
                return Ok(_unit.Departments.Delete(department));
            return BadRequest(new { Message = "Incorrect data." });
        }



    }
}