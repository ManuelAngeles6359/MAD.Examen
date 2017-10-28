using MAD.Examen.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using MAD.Examen.Models;

namespace MAD.Examen.WebApi.Controllers
{

    [Route("api/Person")]
    public class PersonController : BaseController
    {
        public PersonController(IUnitOfWork unit) : base(unit)
        {
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(_unit.Persons.GetList());
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unit.Persons.GetById(id));
        }


        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (ModelState.IsValid)
                return Ok(_unit.Persons.Insert(person));
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (ModelState.IsValid && _unit.Persons.Update(person) && person.PersonID > 0)
                return Ok(new { Message = "The person is updated" });

            return BadRequest(ModelState);

        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Person person)
        {
            if (person.PersonID > 0)
                return Ok(_unit.Persons.Delete(person));
            return BadRequest(new { Message = "Incorrect data." });
        }


    }
}