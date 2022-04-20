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
    public class BeerService : BaseService<Beer>, IBeerRepository
    {
        public BeerService(IConfiguration config) : base(config, "Beer")
        {

        }

        internal override Beer Converter(SqlDataReader reader)
        {
            return new Beer
            {
                Id = (int)reader["Id"],
                Name = (string)reader["Name"],
                Origin = (string)reader["Origin"],
                Degree = (decimal)reader["Degree"]
            };
        }

        public void Create(Beer b)
        {
            Connection cnx = new Connection(_connectionString);
            string sql = "INSERT INTO Beer (Name, Degree, Origin) VALUES (@name, @degree,@origin)";
            Command cmd = new Command(sql);

            cmd.AddParameter("name", b.Name);
            cmd.AddParameter("degree", b.Degree);
            cmd.AddParameter("origin", b.Origin);

            cnx.ExecuteNonQuery(cmd);
        }

        public void Update(Beer b)
        {
            Connection cnx = new Connection(_connectionString);
            string sql = "UPDATE Beer SET Name = @name, Degree = @degree, Origin = @origin WHERE Id = @id";
            Command cmd = new Command(sql);

            cmd.AddParameter("name", b.Name);
            cmd.AddParameter("degree", b.Degree);
            cmd.AddParameter("origin", b.Origin);
            cmd.AddParameter("id", b.Id);

            cnx.ExecuteNonQuery(cmd);
        }

        public void Delete(int Id)
        {
            Connection cnx = new Connection(_connectionString);

            string sql = "DELETE FROM Beer WHERE Id = @id";
            Command cmd = new Command(sql);
            cmd.AddParameter("id", Id);

            cnx.ExecuteNonQuery(cmd);

        }

        public IEnumerable<Beer> GetFavoriteByUserId(int id)
        {
            Connection cnx = new Connection(_connectionString);
            string sql = "SELECT * FROM V_FavoriteBeer WHERE uid = @id";

            Command cmd = new Command(sql);
            cmd.AddParameter("id", id);

            return cnx.ExecuteReader(cmd, Converter);
        }

        public void AddFavorite(int userId, int beerId)
        {
            Connection conn = new Connection(_connectionString);
            Command cmd = new Command("INSERT INTO FavoriteBeer (AppUserId, BeerId) VALUES (@uid, @bid)");

            cmd.AddParameter("uid", userId);
            cmd.AddParameter("bid", beerId);

            conn.ExecuteNonQuery(cmd);
        }
    }
}
