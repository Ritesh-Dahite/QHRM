using Dapper;
using Microsoft.Data.SqlClient;
using QHRM.Infrastructure.IRepository;
using System.Data;

namespace QHRM.Infrastructure.Repository
{
    public class DapperServices : IDapperServices
    {
        private readonly IConfiguration _config;
        private string ConnectionString = "DefaultConnection";

        public DapperServices(IConfiguration config)
        {
            _config = config;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int ExecuteScaler<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString));
            return db.Execute(sp, parms, commandType: commandType);
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IDbConnection db = new SqlConnection(_config.GetConnectionString(ConnectionString));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }
    }
}