using Dapper;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public class BaseDL<T> : IBaseDL<T>
    {
        #region Field

        private IConnectionDL _connectionDL;

        #endregion

        #region Constructor

        public BaseDL(IConnectionDL connectionDL)
        {
            _connectionDL = connectionDL;
        }

        #endregion

        /// <summary>
        /// Hàm check mã trùng
        /// </summary>
        /// <param name="recordCode"></param>
        /// <param name="recordID"></param>
        /// <returns>kiểm tra mã có trùng hay không </returns>
        /// CreatedBy: NDDuy (12/01/2023)
        public bool CheckDuplicateCode(string? recordCode, Guid? recordID)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = String.Format(ProcedureName.CHECK_DUPLICATE_CODE, typeof(T).Name);

            // Chuẩn bị tham số đầu vào
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}Code", recordCode);
            parameters.Add($"@{typeof(T).Name}ID", recordID);

            var DuplicateCode = default(T);

            // Khởi tạo kết nối đến DB
            var connectionString = DataContext.ConnectionString;
            using (var mySqlConnection = _connectionDL.InitConnection(connectionString))
            {
                DuplicateCode = _connectionDL.QueryFirstOrDefault<T>(mySqlConnection, storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return DuplicateCode != null;
        }

        /// <summary>
        /// Hàm thêm mới bản ghi
        /// </summary>
        /// <param name="newRecord">Thông tin của bản ghi cần thêm mới</param>
        public int CreateRecord(T newRecord)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = String.Format(ProcedureName.INSERT, typeof(T).Name);

            //Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            var properties = typeof(Employee).GetProperties();
            var newRecordID = Guid.NewGuid();
            foreach (var prop in properties)
            {
                parameters.Add($"{prop.Name}", prop.GetValue(newRecord));
            }
            parameters.Add($"@{typeof(T).Name}Id", newRecordID);

            var numberOfAffectedRows = 0;

            // Khởi tạo kết nối đến DB
            var connectionString = DataContext.ConnectionString;
            using (var mySqlConnection = _connectionDL.InitConnection(connectionString))
            {
                // Gọi vào DB để chạy stored ở trên
                numberOfAffectedRows = _connectionDL.Execute(mySqlConnection, storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }

        /// <summary>
        /// Hàm xoá bản ghi theo ID
        /// </summary>
        /// <returns>ID bản ghi đã xoá</returns>
        /// Createdby : NDDuy (06/01/2023)
        public T DeleteRecordByID(Guid recordID)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = String.Format(ProcedureName.DELETE_BY_ID, typeof(T).Name);

            //Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}ID", recordID);

            //Khởi tạo kết nối tới database
            T? record;
            var connectionString = DataContext.ConnectionString;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                record = mySqlConnection.QueryFirstOrDefault<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return record;
            //Thực hiện gọi vào database để chạy stored procedure
        }

        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tổng các bản ghi</returns>
        /// Createdby : NDDuy (06/01/2023)
        public IEnumerable<T> GetAllRecord()
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = String.Format(ProcedureName.GET_ALL, typeof(T).Name);

            //Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();

            //Khởi tạo kết nối tới database

            var connectionString = DataContext.ConnectionString;
            var mySqlConnection = new MySqlConnection(connectionString);

            //Thực hiện gọi vào database để chạy stored procedure
            var records = mySqlConnection.Query<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return records;
        }

        /// <summary>
        /// Hàm lấy bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>Chi tiết 1 bản ghi</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        public T GetRecordByID(Guid recordID)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = String.Format(ProcedureName.GET_BY_ID, typeof(T).Name);

            //Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}ID", recordID);

            //Khởi tạo kết nối tới database
            T? record;
            var connectionString = DataContext.ConnectionString;
            using (var mySqlConnection = new MySqlConnection(connectionString))
            {
                record = mySqlConnection.QueryFirstOrDefault<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return record;
            //Thực hiện gọi vào database để chạy stored procedure

        }

        /// <summary>
        /// Hàm sửa một nhân viên
        /// </summary>
        /// <param name="recordID">Id của nhân viên cần sửa</param>
        /// <returns>mã nhân viên vừa sửa</returns>
        public int UpdateRecord(Guid recordID, T newRecord)
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = String.Format(ProcedureName.UPDATE_BY_ID, typeof(T).Name);

            //Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            var properties = typeof(Employee).GetProperties();
            foreach (var prop in properties)
            {
                parameters.Add($"@{prop.Name}", prop.GetValue(newRecord));
            }
            parameters.Add($"@{typeof(T).Name}ID", recordID);

            var numberOfAffectedRows = 0;

            // Khởi tạo kết nối đến DB
            var connectionString = DataContext.ConnectionString;
            using (var mySqlConnection = _connectionDL.InitConnection(connectionString))
            {
                // Gọi vào DB để chạy stored ở trên
                numberOfAffectedRows = _connectionDL.Execute(mySqlConnection, storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            return numberOfAffectedRows;
        }

        /// <summary>
        /// Hàm lấy bản ghi theo keyword và paging
        /// </summary>
        /// <param name="ms_PageIndex">Vị trí trang</param>
        /// <param name="ms_PageSize">Số bản ghi trên 1 trang</param>
        /// <param name="ms_Search">Keyword</param>
        /// <returns>Danh sách bản ghi thoả mãn</returns>
        public IEnumerable<T> GetRecordFilterPaging(int? ms_PageIndex = 1, int? ms_PageSize = 10, string? ms_Search = "")
        {
            //Chuẩn bị tên stored procedure
            string storedProcedureName = String.Format(ProcedureName.GET_BY_FILTER, typeof(T).Name);

            //Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add("ms_PageIndex", ms_PageIndex);
            parameters.Add("ms_PageSize", ms_PageSize);
            parameters.Add("ms_Search", ms_Search);
            parameters.Add("ms_TotalCount", direction: System.Data.ParameterDirection.Output);
            //Khởi tạo kết nối tới database
            var connectionString = DataContext.ConnectionString;
            var mySqlConnection = new MySqlConnection(connectionString);
            //Thực hiện gọi vào database để chạy stored procedure
            var records = mySqlConnection.Query<T>(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            return records;
        }
    }
}
