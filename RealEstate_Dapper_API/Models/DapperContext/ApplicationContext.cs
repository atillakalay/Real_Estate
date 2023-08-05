using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_API.Models.DapperContext
{
    public class ApplicationContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MyConnectionString");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
