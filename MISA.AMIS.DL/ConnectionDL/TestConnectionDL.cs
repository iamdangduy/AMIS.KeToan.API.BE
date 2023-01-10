using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL.ConnectionDL
{
    public class TestConnectionDL : IConnectionDL
    {
        public int Execute(IDbConnection cnn, string storedProcedureName, DynamicParameters parameters, CommandType commandType)
        {
            return 1;
        }

        public IDbConnection InitConnection(string connectionString)
        {
            throw new NotImplementedException();
        }

        public T QueryFirstOrDefault<T>(IDbConnection cnn, string storedProcedureName, DynamicParameters parameters, CommandType commandType)
        {
            return default;
        }
    }
}
