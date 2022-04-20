using AdoToolbox;
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
    public abstract class BaseService<TResult> : IBaseRepository<TResult>
    {
        private readonly IConfiguration _config;
        protected readonly string _connectionString;
        private string _tableName;

        public BaseService(IConfiguration config, string tableName)
        {
            _tableName = tableName;
            _connectionString = config.GetConnectionString("default");
        }

        internal abstract TResult Converter(SqlDataReader reader);

        public virtual IEnumerable<TResult> GetAll()
        {
            Connection connection = new Connection(_connectionString);
            string sql = "SELECT * FROM " + _tableName;

            Command cmd = new Command(sql);

            return connection.ExecuteReader(cmd, Converter);
        }

        public virtual TResult GetById(int Id)
        {
            Connection connection = new Connection(_connectionString);
            string sql = "SELECT * FROM " + _tableName + " WHERE Id = @Id";

            Command cmd = new Command(sql);
            cmd.AddParameter("Id", Id);

            return connection.ExecuteReader(cmd, Converter).FirstOrDefault();
        }
    }
}
