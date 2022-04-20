using CorrectifSecu_BLL.LocalModels;
using CorrectifSecu_BLL.Tools;
using CorrectifSecu_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectifSecu_BLL.LocalServices
{
    public class LocalUserService
    {
        private readonly IAppUserRepository _userRepo;
        private readonly IBeerRepository _beerRepo;

        public LocalUserService(IAppUserRepository userRepo, IBeerRepository beerRepo)
        {
            _userRepo = userRepo;
            _beerRepo = beerRepo;
        }

        public CompleteAppUser GetCompleteUser(int Id)
        {
            CompleteAppUser result = _userRepo.GetById(Id).ToLocal();
            result.FavoriteBeers = _beerRepo.GetFavoriteByUserId(Id);
            return result;
        }

        public void RegisterUser(CreateUserModel m)
        {
            int newUserId = _userRepo.Register(m.Email, m.Password, m.Nickname);

            foreach (int beerId in m.FavoriteId)
            {
                _beerRepo.AddFavorite(newUserId, beerId);
            }
        }
    }
}
