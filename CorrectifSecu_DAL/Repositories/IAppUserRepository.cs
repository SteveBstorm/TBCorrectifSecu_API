using CorrectifSecu_DAL.Models;

namespace CorrectifSecu_DAL.Repositories
{
    public interface IAppUserRepository : IBaseRepository<AppUser>
    {
        AppUser Login(string email, string password);
        int Register(string email, string password, string nickname);
    }
}