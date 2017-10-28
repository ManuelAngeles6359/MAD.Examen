using MAD.Examen.Models;
using Microsoft.EntityFrameworkCore;
using MAD.Examen.Repositories.School;

namespace MAD.Examen.Repositories.EntityFramework.School
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}
