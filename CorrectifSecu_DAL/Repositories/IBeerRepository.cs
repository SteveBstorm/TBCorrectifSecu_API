using CorrectifSecu_DAL.Models;

namespace CorrectifSecu_DAL.Repositories
{
    public interface IBeerRepository : IBaseRepository<Beer>
    {
        void Create(Beer b);
        void Delete(int Id);
        void Update(Beer b);
        IEnumerable<Beer> GetFavoriteByUserId(int id);
        void AddFavorite(int userId, int beerId);
    }
}