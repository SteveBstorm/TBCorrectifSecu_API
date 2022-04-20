using CorrectifSecu_BLL.LocalModels;
using CorrectifSecu_DAL.Models;
using CorrectifSecu_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectifSecu_BLL.Tools
{
    public static class Mappers
    {
        public static CompleteAppUser ToLocal(this AppUser u)
        {
            return new CompleteAppUser
            {
                Id = u.Id,
                Nickname = u.Nickname,
                Email = u.Email,
                Role = u.Role
            };
        }
    }
}
