using MAD.Examen.Models;

namespace MAD.Examen.Repositories.School
{
    public interface IUserRepository: IRepository<User>
    {

        User ValidaterUser(string email, string password);

    }
}
