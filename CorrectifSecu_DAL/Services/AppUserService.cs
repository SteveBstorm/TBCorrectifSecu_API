using AdoToolbox;
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
    public class AppUserService : BaseService<AppUser>, IAppUserRepository
    {
        public AppUserService(IConfiguration config) : base(config, "V_AppUser")
        {

        }

        internal override AppUser Converter(SqlDataReader reader)
        {
            return new AppUser
            {
                Id = (int)reader["Id"],
                Nickname = (string)reader["NickName"],
                Email = (string)reader["Email"],
                Role = (string)reader["Role"]
            };
        }

        public AppUser Login(string email, string password)
        {
            Connection connection = new Connection(_connectionString);
            Command cmd = new Command("AppUserLogin", true);

            cmd.AddParameter("email", email);
            cmd.AddParameter("passwd", password);

            try
            {
                return connection.ExecuteReader(cmd, Converter).First();
            }
            catch (SqlException ex)
            {
                throw new ArgumentNullException("User inéxistant");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Register(string email, string password, string nickname)
        {
            Connection connection = new Connection(_connectionString);
            Command cmd = new Command("AppUserRegister", true);

            cmd.AddParameter("email", email);
            cmd.AddParameter("passwd", password);
            cmd.AddParameter("nickname", nickname);

            return (int)connection.ExecuteScalar(cmd);
        }

        

    }
}
