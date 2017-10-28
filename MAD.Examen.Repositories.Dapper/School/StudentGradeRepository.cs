using MAD.Examen.Models;
using MAD.Examen.Repositories.School;

namespace MAD.Examen.Repositories.Dapper.School
{
    public class StudentGradeRepository : Repository<StudentGrade>, IStudentGradeRepository
    {
        public StudentGradeRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
