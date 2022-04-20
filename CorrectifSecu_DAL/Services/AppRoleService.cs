using CorrectifSecu_DAL.Models;
using CorrectifSecu_DAL.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectifSecu_DAL.Services
{
    public class AppRoleService : BaseService<AppRole>, IAppRoleRepository
    {
        public AppRoleService(IConfiguration config) : base(config, "AppRole")
        {

        }
        internal override AppRole Converter(SqlDataReader reader)
        {
            return new AppRole
            {
                Id = (int)reader["Id"],
                RoleName = (string)reader["RoleName"]
            };
        }
    }
}
