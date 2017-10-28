using MAD.Examen.Models;
using MAD.Examen.Repositories.School;
using Microsoft.EntityFrameworkCore;

namespace MAD.Examen.Repositories.EntityFramework.School
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
