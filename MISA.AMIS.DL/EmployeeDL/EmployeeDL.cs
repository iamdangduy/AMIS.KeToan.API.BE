using Dapper;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.DL;
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

        //public EmployeeDL(IConnectionDL connectionDL) : base(connectionDL)
        //{
        //    _connectionDL = connectionDL;
        //}

        #endregion

        //public int CreatedEmployee(Employee newEmployee)
        //{
        //    // Chuẩn bị chuỗi kết nối
        //    var connectionString = DataContext.ConnectionString;

        //    // Chuẩn bị tên stored procedure
        //    var storedProcedureName = $"Proc_employee_Insert";

        //    // Chuẩn bị tham số đầu vào cho procedure
        //    var parameters = new DynamicParameters();
        //    var newID = Guid.NewGuid();
        //    var properties = typeof(Employee).GetProperties();


        //    var numberOfAffectedRows = 0;

        //    // Khởi tạo kết nối đến DB
        //    using (var mySqlConnection = _connectionDL.InitConnection(connectionString))
        //    {
        //        // Gọi vào DB để chạy stored ở trên
        //        numberOfAffectedRows = _connectionDL.Execute(mySqlConnection, storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //    }

        //    return numberOfAffectedRows;
        //}

        public string GetNewCode()
        {
            throw new NotImplementedException();
        }


    }
}
