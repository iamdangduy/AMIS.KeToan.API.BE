using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public class MySqlConnectionDL : IConnectionDL
    {
        #region Field

        private IDbConnection? _mySqlConnection;

        #endregion

        #region Method

        public int Execute(IDbConnection cnn,string storedProcedureName, DynamicParameters parameters, CommandType commandType)
        {
            var numberOfAffectedRows = _mySqlConnection.Execute(storedProcedureName, parameters, null, null, commandType);

            return numberOfAffectedRows;
        }

        public IDbConnection InitConnection(string connectionString)
        {
            _mySqlConnection = new MySqlConnection(DataContext.ConnectionString);

            return _mySqlConnection;
        }

        public T QueryFirstOrDefault<T>(IDbConnection cnn, string storedProcedureName, DynamicParameters parameters, CommandType commandType)
        {
            return cnn.QueryFirstOrDefault<T>(storedProcedureName, parameters, null, null, commandType);
        }

        #endregion
    }
}
