using MAD.Examen.Models;
using MAD.Examen.Repositories.School;

namespace MAD.Examen.Repositories.Dapper.School
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(string connectionString) : base(connectionString)
        {
        }
    }
}
