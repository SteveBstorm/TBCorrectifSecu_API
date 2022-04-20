
namespace CorrectifSecu_DAL.Repositories
{
    public interface IBaseRepository<TResult>
    {
        IEnumerable<TResult> GetAll();
        TResult GetById(int Id);
    }
}