using AutoFixture;
using MAD.Examen.Models;
using MAD.Examen.Repositories.School;
using MAD.Examen.UnitOfWork;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace MAD.Examen.Mocked
{
    public class PersonMocked
    {
                
        private List<Person> _persons;

        public PersonMocked()
        {
            _persons = Persons();
        }

        private List<Person> Persons()
        {
            var fixture = new Fixture();
            var persons = fixture.CreateMany<Person>(50).ToList();

            for (int i = 0; i < 50; i++)
            {
                persons[i].PersonID = i + 1;
            }

            return persons;
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Persons).Returns(PersonRepositoryMocked());
            return mocked.Object;

        }

        private IPersonRepository PersonRepositoryMocked()
        {
            var personMocked = new Mock<IPersonRepository>();
            personMocked.Setup(c => c.GetList()).Returns(_persons);
            personMocked.Setup(c => c.Insert(It.IsAny<Person>())).Callback<Person>((c) =>
               _persons.Add(c)).Returns<Person>(c => c.PersonID);

            personMocked.Setup(c => c.Update(It.IsAny<Person>())).Callback<Person>((c) =>
            {
                _persons.RemoveAll(pers => pers.PersonID == c.PersonID);
                _persons.Add(c);
            }).Returns(true);

            personMocked.Setup(c => c.Delete(It.IsAny<Person>())).Callback<Person>((c) => _persons.RemoveAll(pers => pers.PersonID == c.PersonID)).Returns(true);
            personMocked.Setup(c => c.GetById(It.IsAny<int>())).Returns((int id) => _persons.FirstOrDefault(pers => pers.PersonID == id));

            return personMocked.Object;
        }




    }
}
