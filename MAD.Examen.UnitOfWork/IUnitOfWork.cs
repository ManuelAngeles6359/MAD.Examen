using MAD.Examen.Repositories.School;

namespace MAD.Examen.UnitOfWork
{
    public interface IUnitOfWork
    {

        IPersonRepository Persons { get; }
        IDepartmentRepository Departments { get; }
        ICourseRepository Courses { get; }
        IStudentGradeRepository StudentGrades { get; }
        IUserRepository Users { get; }

    }
}
