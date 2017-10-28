using MAD.Examen.Models;
using MAD.Examen.Repositories.School;

namespace MAD.Examen.Repositories.Dapper.School
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
