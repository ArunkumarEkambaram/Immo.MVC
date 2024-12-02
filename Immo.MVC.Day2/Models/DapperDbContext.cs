using System.Data;
using System.Data.SqlClient;

namespace Immo.MVC.Day2.Models
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("ImmoDBConn");
        }

        public IDbConnection GetConnection { get => new SqlConnection(_connectionString); }
    }
}
