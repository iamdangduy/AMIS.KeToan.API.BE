using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.DL;
using MySqlConnector;

namespace MISA.AMIS.KeToan.API.Controllers
{

    public class EmployeesController : BasesController<Employee>
    {
        public string devValidates;
        protected bool isCheck;

        #region Field

        private IEmployeeBL _employeeBL;

        #endregion

        #region Constructor

        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }

        #endregion

        /// <summary>
        /// Hàm lấy giá trị mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        [HttpGet("maxCodeEmployee")]
        public IActionResult GetMaxEmployeeCode()
        {
            try
            {
                var maxRecordCode = _employeeBL.GetMaxEmployeeCode();
                if (maxRecordCode != null)
                {
                    return StatusCode(StatusCodes.Status200OK, maxRecordCode);
                }
                else
                {
                    return StatusCode(500, new ErrorResult
                    {
                        ErrorCode = AmisErrorCode.GetMaxCodeFailed,
                        DevMsg = "Gọi procedure thất bại ",
                        UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
                        MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/7",
                        TraceId = HttpContext.TraceIdentifier
                    });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, new ErrorResult
                {
                    ErrorCode = AmisErrorCode.GetMaxCodeFailed,
                    DevMsg = "Gọi procedure thất bại " + e.Message,
                    UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
                    MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/7",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Hàm filter, paging nhân theoe mã nhân viên/tên nhân viên
        /// </summary>
        /// <param name="ms_PageIndex">Số trang</param>
        /// <param name="ms_PageSize">Số bản ghi 1 trang</param>
        /// <param name="ms_Search">Dữ liệu cần tìm kiếm</param>
        /// <returns>Số bản ghi hợp lệ</returns>
        //[HttpGet("filter")]
        //public IActionResult GetEmployeeByFilter(int? ms_PageIndex = 1, int? ms_PageSize = 10, string? ms_Search = "")
        //{
        //    try
        //    {

        //        //Chuẩn bị tên stored procedure
        //        string storedProcedureName = "Proc_employee_Paging";

        //        //Chuẩn bị tham số đầu vào cho stored procedure
        //        var parameters = new DynamicParameters();
        //        parameters.Add("ms_PageIndex", ms_PageIndex);
        //        parameters.Add("ms_PageSize", ms_PageSize);
        //        parameters.Add("ms_Search", ms_Search);
        //        parameters.Add("ms_TotalCount", direction: System.Data.ParameterDirection.Output);

        //        //Khởi tạo kết nối tới database
        //        var connectionString = DataContext.ConnectionString;
        //        var mySqlConnection = new MySqlConnection(connectionString);

        //        //Thực hiện gọi vào database để chạy stored procedure

        //        var employeeListPages = mySqlConnection.Query(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //        var totalCount = parameters.Get<int>("ms_TotalCount");
        //        //Xử lí kết quả trả về
        //        if (employeeListPages != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, new
        //            {
        //                totalcount = totalCount,
        //                res = employeeListPages
        //            }); ;
        //        }

        //        else
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
        //            {
        //                ErrorCode = AmisErrorCode.GetEmployeeFilterFailed,
        //                DevMsg = devValidates,
        //                UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
        //                MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/8",
        //                TraceId = HttpContext.TraceIdentifier
        //            });

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
        //        {
        //            ErrorCode = Common.Enums.AmisErrorCode.GetEmployeeFilterFailedExc,
        //            DevMsg = "Có lỗi xảy ra",
        //            UserMsg = "Có lỗi xảy ra, vui lòng thử lại",
        //            MoreInfo = "https://onpenapi.com.vn/amis/error-code/9",
        //            TraceId = HttpContext.TraceIdentifier,
        //        });
        //    }

        //}

    }
}
