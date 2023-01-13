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
        /// API lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        /// Createdby: NDDuy
        //[HttpGet]
        //public IActionResult GetAllEmpoloyees()
        //{
        //    try
        //    {
        //        //Validate dữ liệu đầu vào

        //        //Chuẩn bị tên stored procedure
        //        string storedProcedureName = "Proc_employee_GetAllEmployee";

        //        //Chuẩn bị tham số đầu vào cho stored procedure

        //        //Khởi tạo kết nối tới database
        //        string connectionString = "Server=localhost;Port=3306;Database=amis.ke_toan;Uid=root;Pwd=nguyenduy18;";
        //        var mySqlConnection = new MySqlConnection(connectionString);

        //        //Thực hiện gọi vào database để chạy stored procedure
        //        var employees = mySqlConnection.Query(storedProcedureName, commandType: System.Data.CommandType.StoredProcedure);

        //        //Xử lí kết quả trả về
        //        if (employees != null)
        //        {
        //            return StatusCode(StatusCodes.Status200OK, employees);
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status404NotFound, new ErrorResult
        //            {
        //                ErrorCode = AmisErrorCode.GetEmployeeByExc,
        //                DevMsg = "Gọi procedure thất bại ",
        //                UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
        //                MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/6",
        //                TraceId = HttpContext.TraceIdentifier
        //            });
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
        //        {
        //            ErrorCode = AmisErrorCode.GetEmployeeByExc,
        //            DevMsg = "Có lỗi xảy ra",
        //            UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
        //            MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/6",
        //            TraceId = HttpContext.TraceIdentifier
        //        });
        //    }
        //}

        /// <summary>
        /// API get một nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn get</param>
        /// <returns>Thông tin nhân viên</returns>
        /// Createdby: NDDuy
        //[HttpGet("{employeeID}")]
        //public IActionResult GetEmployeeByID([FromRoute] Guid? employeeID)
        //{
        //    try
        //    {
        //        //Validate dữ liệu đầu vào
        //        this.isCheck = true;
        //        if (employeeID == null)
        //        {
        //            this.isCheck = false;
        //            devValidates = "Mã nhân viên không được phép để trống";
        //        }

        //        //Chuẩn bị tên stored procedure
        //        string storedProcedureName = "Proc_employee_GetByID";

        //        //Chuẩn bị tham số đầu vào cho stored procedure
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@EmployeeID", employeeID);

        //        //Khởi tạo kết nối tới database
        //        string connectionString = "Server=localhost;Port=3306;Database=amis.ke_toan;Uid=root;Pwd=nguyenduy18;";
        //        var mySqlConnection = new MySqlConnection(connectionString);

        //        //Thực hiện gọi vào database để chạy stored procedure
        //        if (this.isCheck == true)
        //        {
        //            var employees = mySqlConnection.QueryFirstOrDefault(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //            //Xử lí kết quả trả về
        //            if (employees != null)
        //            {
        //                return StatusCode(StatusCodes.Status200OK, employees);
        //            }
        //            else
        //            {
        //                return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
        //                {
        //                    ErrorCode = AmisErrorCode.GetEmployeeByIDFailed,
        //                    DevMsg = devValidates,
        //                    UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
        //                    MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/2",
        //                    TraceId = HttpContext.TraceIdentifier
        //                });
        //            }

        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
        //            {
        //                ErrorCode = AmisErrorCode.GetEmployeeByIDFailed,
        //                DevMsg = "Không tìm thấy nhân viên có mã: " + employeeID,
        //                UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
        //                MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/2",
        //                TraceId = HttpContext.TraceIdentifier
        //            });
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return StatusCode(500, new ErrorResult
        //        {
        //            ErrorCode = AmisErrorCode.GetEmployeeByIDExc,
        //            DevMsg = "Gọi procedure thất bại ",
        //            UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
        //            MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/3",
        //            TraceId = HttpContext.TraceIdentifier
        //        });
        //    }

        //}

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

        [HttpGet("filter")]
        public IActionResult GetEmployeeByFilter(int? ms_PageIndex = 1, int? ms_PageSize = 10, string? ms_Search = "")
        {
            try
            {

                //Chuẩn bị tên stored procedure
                string storedProcedureName = "Proc_employee_Paging";

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

                var employeeListPages = mySqlConnection.Query(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var totalCount = parameters.Get<int>("ms_TotalCount");
                //Xử lí kết quả trả về
                if (employeeListPages != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new
                    {
                        totalcount = totalCount,
                        res = employeeListPages
                    }); ;
                }

                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = AmisErrorCode.GetEmployeeFilterFailed,
                        DevMsg = devValidates,
                        UserMsg = "Lấy nhân viên thất bại, vui lòng thử lại ",
                        MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/8",
                        TraceId = HttpContext.TraceIdentifier
                    });

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = Common.Enums.AmisErrorCode.GetEmployeeFilterFailedExc,
                    DevMsg = "Có lỗi xảy ra",
                    UserMsg = "Có lỗi xảy ra, vui lòng thử lại",
                    MoreInfo = "https://onpenapi.com.vn/amis/error-code/9",
                    TraceId = HttpContext.TraceIdentifier,
                });
            }

        }

        /// <summary>
        /// API thêm mới nhân viên
        /// </summary>
        /// <param name="newEmployee">Nhân viên cần thêm</param>
        /// <returns>ID nhân viên vừa thêm</returns>
        /// Createdby: NDDuy
        //[HttpPost]
        //public IActionResult CreateEmployee([FromBody] Employee newEmployee)
        //{
        //    try
        //    {
        //        this.isCheck = true;

        //        //Validate dữ liệu đầu vào
        //        if (string.IsNullOrEmpty(newEmployee.EmployeeName))
        //        {
        //            this.isCheck = false;
        //            devValidates = "Tên không được để trống";
        //        }
        //        else if (string.IsNullOrEmpty(newEmployee.EmployeeCode))
        //        {
        //            this.isCheck = false;
        //            devValidates = "Mã nhân viên không được để trống";
        //        }
        //        else if (newEmployee.DepartmentID == null || newEmployee.DepartmentID == 0)
        //        {
        //            this.isCheck = false;
        //            devValidates = "Mã phòng ban không được để trống";
        //        }
        //        //Chuẩn bị tên stored procedure
        //        string storedProcedureName = "Proc_employee_Insert";

        //        //Chuẩn bị tham số đầu vào cho stored procedure
        //        var parameters = new DynamicParameters();
        //        var newEmployeeID = Guid.NewGuid();
        //        parameters.Add("@EmployeeID", newEmployeeID);
        //        parameters.Add("@EmployeeCode", newEmployee.EmployeeCode);
        //        parameters.Add("@EmployeeName", newEmployee.EmployeeName);
        //        parameters.Add("@Email", newEmployee.Email);
        //        parameters.Add("@PhoneNumber", newEmployee.PhoneNumber);
        //        parameters.Add("@DepartmentID", newEmployee.DepartmentID);
        //        parameters.Add("@DateOfBirth", newEmployee.DateOfBirth);
        //        parameters.Add("@Gender", newEmployee.Gender);
        //        parameters.Add("@IdentityNumber", newEmployee.IdentityNumber);
        //        parameters.Add("@IssuedDate", newEmployee.IssuedDate);
        //        parameters.Add("@CreatedBy", newEmployee.CreatedBy);
        //        parameters.Add("@ModifiedBy", newEmployee.ModifiedBy);
        //        parameters.Add("@Address", newEmployee.Address);
        //        parameters.Add("@IssuedPlace", newEmployee.IssuedPlace);
        //        parameters.Add("@ModifiedDate", newEmployee.ModifiedDate);

        //        //Khởi tạo kết nối tới database
        //        string connectionString = "Server=localhost;Port=3306;Database=amis.ke_toan;Uid=root;Pwd=nguyenduy18;";
        //        var mySqlConnection = new MySqlConnection(connectionString);


        //        var numberOfAffectedRows = 0;
        //        //Thực hiện gọi vào database để chạy stored procedure
        //        if (this.isCheck == true)
        //        {
        //            numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //        }

        //        //Xử lí kết quả trả về
        //        if (numberOfAffectedRows > 0)
        //        {
        //            return StatusCode(StatusCodes.Status201Created, newEmployeeID);
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
        //            {
        //                ErrorCode = Common.Enums.AmisErrorCode.InsertFailed,
        //                DevMsg = devValidates,

        //                UserMsg = "Thêm mới thất bại, vui lòng thử lại",
        //                MoreInfo = "https://onpenapi.com.vn/amis/error-code/1",
        //                TraceId = HttpContext.TraceIdentifier,
        //            });
        //        }

        //        //Thành công

        //        //Thất bại

        //        //try catch

        //    }

        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
        //        {
        //            ErrorCode = Common.Enums.AmisErrorCode.Exception,
        //            DevMsg = devValidates,

        //            UserMsg = "Thêm mới thất bại, vui lòng thử lại",
        //            MoreInfo = "https://onpenapi.com.vn/amis/error-code/0",
        //            TraceId = HttpContext.TraceIdentifier,
        //        });
        //    }

        //}

        /// <summary>
        /// API sửa một nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn sửa</param>
        /// <param name="employee">Thông tin của nhân viên sửa</param>
        /// <returns>Nhân viên vừa thêm</returns>
        /// Createdby: NDDuy
        //[HttpPut("{employeeID}")]
        //public IActionResult UpdateEmployee([FromRoute] Guid employeeID, [FromBody] Employee employee)
        //{
        //    try
        //    {
        //        this.isCheck = true;
        //        //Validate dữ liệu đầu vào
        //        if (employee.EmployeeCode == "")
        //        {
        //            this.isCheck = false;
        //            devValidates = "Mã nhân viên không được phép để trống";
        //        }
        //        else if (employee.EmployeeName == "")
        //        {
        //            this.isCheck = false;
        //            devValidates = "Tên nhân viên không được phép để trống";
        //        }
        //        else if (employee.DepartmentID == "")
        //        {
        //            this.isCheck = false;
        //            devValidates = "Mã phòng ban không được phép để trống";
        //        }

        //        //Chuẩn bị tên stored procedure
        //        string storedProcedureName = "Proc_employee_UpdateEmployee";

        //        //Chuẩn bị tham số đầu vào cho stored procedure
        //        var parameters = new DynamicParameters();
        //        parameters.Add("ms_EmployeeID", employeeID);
        //        parameters.Add("@EmployeeCode", employee.EmployeeCode);
        //        parameters.Add("ms_EmployeeName", employee.EmployeeName);
        //        parameters.Add("@Email", employee.Email);
        //        parameters.Add("@PhoneNumber", employee.PhoneNumber);
        //        parameters.Add("@DepartmentID", employee.DepartmentID);
        //        parameters.Add("@DateOfBirth", employee.DateOfBirth);
        //        parameters.Add("@Gender", employee.Gender);
        //        parameters.Add("@IdentityNumber", employee.IdentityNumber);
        //        parameters.Add("@IssuedDate", employee.IssuedDate);
        //        parameters.Add("@ModifiedBy", employee.ModifiedBy);
        //        parameters.Add("@Address", employee.Address);
        //        parameters.Add("@IssuedPlace", employee.IssuedPlace);
        //        parameters.Add("@ModifiedDate", employee.ModifiedDate);

        //        //Khởi tạo kết nối tới database
        //        string connectionString = "Server=localhost;Port=3306;Database=amis.ke_toan;Uid=root;Pwd=nguyenduy18;";
        //        var mySqlConnection = new MySqlConnection(connectionString);

        //        //Thực hiện gọi vào database để chạy stored procedure
        //        var numberOfAffectedRows = 0;
        //        if (this.isCheck == true)
        //        {
        //            numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //        }

        //        //Xử lí kết quả trả về
        //        if (numberOfAffectedRows == 0)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
        //            {
        //                ErrorCode = AmisErrorCode.UpdateEmployeeFailde,
        //                DevMsg = devValidates,
        //                UserMsg = "Cập nhập thông tin nhân viên " + employeeID + " thất bại, vui lòng thử lại",
        //                MoreInfo = "Xem thông tin lỗi chi tiết tại https://openapi/amis/error-code/4",
        //                TraceId = HttpContext.TraceIdentifier
        //            });
        //        }
        //        else
        //        {
        //            return StatusCode(200, employeeID);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
        //        {
        //            ErrorCode = AmisErrorCode.UpdateEmployeeFailde,
        //            DevMsg = "Chạy procedure thất bại " + e.Message,
        //            UserMsg = "Cập nhập thông tin nhân viên " + employeeID + " thất bại, vui lòng thử lại",
        //            MoreInfo = "Xem thông tin lỗi chi tiết tại https://openapi/amis/error-code/4",
        //            TraceId = HttpContext.TraceIdentifier
        //        });
        //    }
        //}

        /// <summary>
        /// API delete một nhân viên
        /// </summary>
        /// <param name="employeeID">ID của nhân viên muốn xoá</param>
        /// <returns>ID của nhân viên vừa xoá</returns>
        /// Createdby: NDDuy
        //[HttpDelete("{employeeID}")]
        //public IActionResult DeleteEmployee([FromRoute] Guid? employeeID)
        //{
        //    try
        //    {
        //        //Validate dữ liệu đầu vào
        //        this.isCheck = true;
        //        if (employeeID == null)
        //        {
        //            this.isCheck = false;
        //            devValidates = "Mã nhân viên không được phép để trống";

        //        }


        //        //Chuẩn bị tên stored procedure
        //        string storedProcedureName = "Proc_employee_DeleteByID";

        //        //Chuẩn bị tham số đầu vào cho stored procedure
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@EmployeeID", employeeID);

        //        //Khởi tạo kết nối tới database
        //        string connectionString = "Server=localhost;Port=3306;Database=amis.ke_toan;Uid=root;Pwd=nguyenduy18;";
        //        var mySqlConnection = new MySqlConnection(connectionString);

        //        //Thực hiện gọi vào database để chạy stored procedure
        //        var numberOfAffectedRows = 0;
        //        if (this.isCheck == true)
        //        {
        //            numberOfAffectedRows = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        //        }

        //        //Xử lí kết quả trả về
        //        if (numberOfAffectedRows > 0)
        //        {
        //            return StatusCode(200, employeeID);
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
        //            {
        //                ErrorCode = AmisErrorCode.DeleteEmployeeFailded,
        //                DevMsg = devValidates,
        //                UserMsg = "Xóa nhân viên " + employeeID + " thất bại!",
        //                MoreInfo = "Xem thông tin chi tiết tại https://openapi/amis/err-code/5",
        //                TraceId = HttpContext.TraceIdentifier
        //            });
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return StatusCode(500, new ErrorResult
        //        {
        //            ErrorCode = AmisErrorCode.DeleteEmployeeFaildedExc,
        //            DevMsg = "Chạy procedure thất bại do : " + e.Message,
        //            UserMsg = "Xóa nhân viên " + employeeID + " thất bại!",
        //            MoreInfo = "Xem thông tin chi tiết tại https://openapi/amis/err-code/10",
        //            TraceId = HttpContext.TraceIdentifier
        //        });
        //    }
        //}

    }
}
