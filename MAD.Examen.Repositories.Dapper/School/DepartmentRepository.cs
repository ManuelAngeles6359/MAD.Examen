using MAD.Examen.Models;
using MAD.Examen.Repositories.School;

namespace MAD.Examen.Repositories.Dapper.School
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
