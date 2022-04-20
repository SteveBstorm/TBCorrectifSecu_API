using DAL = CorrectifSecu_DAL.Models;
using API = CorrectifSecu_API.Models;
using CorrectifSecu_BLL.LocalModels;

namespace CorrectifSecu_API.Tools
{
    public static class Mappers
    {
        public static API.AppUser ToApi(this DAL.AppUser u)
        {
            return new API.AppUser
            {
                Id = u.Id,
                Nickname = u.Nickname,
                Email = u.Email,
                Role = u.Role
            };
        }

        public static API.Beer ToApi(this DAL.Beer b)
        {
            return new API.Beer
            {
                Id = b.Id,
                Name = b.Name,
                Degree = b.Degree,
                Origin = b.Origin
            };
        }

        public static DAL.Beer ToDal(this API.FormCreateBeer f)
        {
            return new DAL.Beer
            {
                Origin = f.Origin,
                Name = f.Name,
                Degree = f.Degree
            };
        }
        public static DAL.Beer ToDal(this API.FormUpdateBeer f)
        {
            return new DAL.Beer
            {
                Id = f.Id,
                Origin = f.Origin,
                Name = f.Name,
                Degree = f.Degree
            };
        }

        public static CreateUserModel ToLocal(this API.FormRegister form)
        {
            return new CreateUserModel
            {
                Email = form.Email,
                Nickname = form.Nickname,
                Password = form.Password,
                FavoriteId = form.FavoriteId
            };
        }
    }
}
