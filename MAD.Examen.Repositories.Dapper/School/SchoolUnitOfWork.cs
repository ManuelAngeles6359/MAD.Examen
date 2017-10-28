using MAD.Examen.Repositories.School;
using MAD.Examen.UnitOfWork;

namespace MAD.Examen.Repositories.Dapper.School
{
    public class SchoolUnitOfWork: IUnitOfWork
    {

        


        public SchoolUnitOfWork(string connectionString)
        {

            Persons = new PersonRepository(connectionString);
            Departments = new DepartmentRepository(connectionString);
            Courses = new CourseRepository(connectionString);
            StudentGrades = new StudentGradeRepository(connectionString);
            Users = new UserRepository(connectionString);

        }


        public IPersonRepository Persons { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public IStudentGradeRepository StudentGrades { get; private set; }
        public IUserRepository Users { get; private set; }
    }



}
