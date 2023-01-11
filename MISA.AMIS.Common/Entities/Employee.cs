
using static MISA.AMIS.Common.MISAAttributes;

namespace MISA.AMIS.Common.Entities
{
    public class Employee
    {
        /// <summary>
        /// Khoá chính
        /// </summary>
        [PrimaryKey]
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [IsNotNullOrEmpty("Mã nhân viên không được để trống")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [IsNotNullOrEmpty("Tên nhân viên không được để trống")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public string? DateOfBirth { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// số CMND
        /// </summary>
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        public string? IssuedDate { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string? IssuedPlace { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public string? CreatedDate { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [IsNotNullOrEmpty("đơn vị không được để trống")]
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa
        /// </summary>
        public string? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }

    }
}
