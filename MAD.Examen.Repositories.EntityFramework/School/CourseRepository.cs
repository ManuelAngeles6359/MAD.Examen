using MAD.Examen.Models;
using MAD.Examen.Repositories.School;
using Microsoft.EntityFrameworkCore;

namespace MAD.Examen.Repositories.EntityFramework.School
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }
    }
}
