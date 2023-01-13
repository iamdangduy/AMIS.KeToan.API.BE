using Dapper;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.DL;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
    {

        #region Field

        private IConnectionDL _connectionDL;

        #endregion


        #region Constructor

        public EmployeeDL(IConnectionDL connectionDL) : base(connectionDL)
        {
            _connectionDL = connectionDL;
        }

        /// <summary>
        /// Trả về mã lớn nhất
        /// </summary>
        /// <returns>Mã lớn nhất</returns>
        /// Created by: NDDuy (05/01/2023)
        public string GetMaxEmployeeCode()
        {
            //Validate dữ liệu đầu vào

            //Chuẩn bị tên stored procedure
            string storedProcedureName = "Proc_employee_GetMaxByEmployeeCode";

            // Chuẩn bị tham số đầu vào

            // Khởi tạo kết nối đến DB
            var connectionString = DataContext.ConnectionString;
            var maxCodeEmployee = "";

            using (var mySqlConnection = _connectionDL.InitConnection(connectionString))
            {
                maxCodeEmployee = mySqlConnection.QueryFirstOrDefault<string>(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);
            }
            return maxCodeEmployee;

        }

        //public EmployeeDL(IConnectionDL connectionDL) : base(connectionDL)
        //{
        //    _connectionDL = connectionDL;
        //}

        #endregion


    }
}
