namespace MISA.AMIS.Common.Enums
{
    public enum AmisErrorCode
    {
        /// <summary>
        /// 
        /// </summary>
        Exception = 0,

        /// <summary>
        /// Insert lỗi
        /// </summary>
        InsertFailed = 1,

        /// <summary>
        /// Lấy nhân viên theo id lỗi
        /// </summary>
        GetEmployeeByIDFailed = 2,

        /// <summary>
        /// Lỗi lấy employee theo ID lọt vào catch
        /// </summary>
        GetEmployeeByIDExc = 3,

        /// <summary>
        /// lỗi không tìm thấy employee
        /// </summary>
        UpdateEmployeeFailde = 4,

        /// <summary>
        /// xóa nhân viên thất bại
        /// </summary>
        DeleteEmployeeFailded = 5,

        /// <summary>
        /// lấy tất cả nhân viên thất bại
        /// </summary>
        GetEmployeeByExc = 6,

        /// <summary>
        /// lấy mã nhân viên lớn nhất thất bại
        /// </summary>
        GetMaxCodeFailed = 7,

        /// <summary>
        /// Lấy nhân viên filter thất bại
        /// </summary>
        GetEmployeeFilterFailed = 8,

        /// <summary>
        /// Lấy nhân viên filter lỗi 500
        /// </summary>
        GetEmployeeFilterFailedExc = 9,

        /// <summary>
        /// Xoá một nhân viên thất bại 500
        /// </summary>
        DeleteEmployeeFaildedExc = 10,

        /// <summary>
        /// Tìm kiếm nhân viên thất bại
        /// </summary>
        GetEmployeeByIDNotFound = 11,
    }
}
