using CorrectifSecu_DAL.Models;
using CorrectifSecu_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectifSecu_BLL.LocalModels
{
    public class CompleteAppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }
        public IEnumerable<Beer> FavoriteBeers { get; set; }

        
    }
}
