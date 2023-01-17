using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Enums;
using MySqlConnector;

namespace MISA.AMIS.KeToan.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasesController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BasesController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method
        [HttpPut("{recordID}")]
        public IActionResult UpdateRecord(Guid recordID, T newRecord)
        {
            try
            {
                var result = _baseBL.UpdateRecord(recordID, newRecord);
                if (result == (int)StatusResponse.Done)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else if (result == (int)StatusResponse.Invalid || result == (int)StatusResponse.DuplicateCode)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = AmisErrorCode.InsertFailed,
                        DevMsg = Resource.DevMsg_InvalidInput,
                        UserMsg = Resource.UserMsg_InvalidInput,
                        MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/1",
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = AmisErrorCode.Exception,
                        DevMsg = Resource.DevMsg,
                        UserMsg = Resource.UserMsg,
                        MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/0",
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AmisErrorCode.GetEmployeeByIDExc,
                    DevMsg = Resource.DevMsg,
                    UserMsg = Resource.UserMsg,
                    MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/3",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        [HttpPost]
        public IActionResult CreateRecord(T newRecord)
        {
            try
            {
                var result = _baseBL.CreateRecord(newRecord);
                // Xử lý kết quả trả về
                if (result == (int)StatusResponse.Done)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else if (result == (int)StatusResponse.Invalid || result == (int)StatusResponse.DuplicateCode)
                {
                    Console.WriteLine(result);
                    return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                    {
                        ErrorCode = AmisErrorCode.InsertFailed,
                        DevMsg = Resource.DevMsg_InvalidInput,
                        UserMsg = Resource.UserMsg_InvalidInput,
                        MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/1",
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                    {
                        ErrorCode = AmisErrorCode.Exception,
                        DevMsg = Resource.DevMsg,
                        UserMsg = Resource.UserMsg,
                        MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/0",
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AmisErrorCode.Exception,
                    DevMsg = Resource.DevMsg,
                    UserMsg = Resource.UserMsg,
                    MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/0",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API xoá bản ghi theo ID
        /// </summary>
        /// <returns>ID của bản ghi cần xoá</returns>
        /// Createdby: NDDuy (10/01/2023)
        [HttpDelete("{recordID}")]
        public IActionResult DeleteRecordByID([FromRoute] Guid recordID)
        {
            try
            {
                var record = _baseBL.DeleteRecordByID(recordID);
                if (record != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AmisErrorCode.GetEmployeeByIDExc,
                    DevMsg = Resource.DevMsg,
                    UserMsg = Resource.UserMsg,
                    MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/3",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API lấy bản ghi theo ID
        /// </summary>
        /// <returns>Thông tin chi tiết bản ghi</returns>
        /// Createdby: NDDuy (10/01/2023)
        [HttpGet("{recordID}")]
        public IActionResult GetRecordByID([FromRoute] Guid recordID)
        {
            try
            {
                var record = _baseBL.GetRecordByID(recordID);
                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResult
                    {
                        ErrorCode = AmisErrorCode.GetEmployeeByIDNotFound,
                        DevMsg = Resource.GetEmployeeByIDNotFound,
                        UserMsg = Resource.GetEmployeeByIDNotFound,
                        MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/3",
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AmisErrorCode.GetEmployeeByIDExc,
                    DevMsg = Resource.DevMsg,
                    UserMsg = Resource.UserMsg,
                    MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/3",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách tất cả nhân viên</returns>
        /// Createdby: NDDuy
        [HttpGet]
        public IActionResult GetAllRecord()
        {
            try
            {
                var records = _baseBL.GetAllRecord();
                if (records != null)
                {
                    return StatusCode(StatusCodes.Status200OK, records);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AmisErrorCode.GetEmployeeByIDExc,
                    DevMsg = Resource.DevMsg,
                    UserMsg = Resource.UserMsg,
                    MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/3",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        [HttpGet("filter")]
        public IActionResult GetRecordFilterPaging(int? ms_PageIndex = 1, int? ms_PageSize = 10, string? ms_Search = "")
        {
            try
            {
                var record = _baseBL.GetRecordFilterPaging(ms_PageIndex, ms_PageSize, ms_Search);
                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
                }
                else
                {
                    return StatusCode(StatusCodes.Status404NotFound, new ErrorResult
                    {
                        ErrorCode = AmisErrorCode.GetEmployeeByIDNotFound,
                        DevMsg = Resource.GetEmployeeByIDNotFound,
                        UserMsg = Resource.GetEmployeeByIDNotFound,
                        MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/3",
                        TraceId = HttpContext.TraceIdentifier
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AmisErrorCode.GetEmployeeByIDExc,
                    DevMsg = Resource.DevMsg,
                    UserMsg = Resource.UserMsg,
                    MoreInfo = "Xem chi tiết lỗi tại https://openapi/amis/employees/err-code/3",
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }
        #endregion
    }
}
