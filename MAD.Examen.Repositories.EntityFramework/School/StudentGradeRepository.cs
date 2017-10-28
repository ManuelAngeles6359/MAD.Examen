using MAD.Examen.Models;
using Microsoft.EntityFrameworkCore;
using MAD.Examen.Repositories.School;

namespace MAD.Examen.Repositories.EntityFramework.School
{
    public class StudentGradeRepository : Repository<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(DbContext context) : base(context)
        {
        }
    }
}
