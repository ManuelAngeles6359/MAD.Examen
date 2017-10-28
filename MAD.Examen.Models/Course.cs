using Dapper.Contrib.Extensions;

namespace MAD.Examen.Models
{
    public class Course
    {

        [Key]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }

    }
}
