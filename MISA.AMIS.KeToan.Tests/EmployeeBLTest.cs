using MISA.AMIS.BL;
using MISA.AMIS.Common;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.DL;
using MISA.AMIS.DL.ConnectionDL;
using NSubstitute;

namespace MISA.AMIS.KeToan.EmployeeTest
{
    public class EmployeeBLTest
    {
        #region Field
        //private IEmployeeDL _employeeDL = new IEmployeeDL(new TestConnectionDL());
        #endregion

        /// <summary>
        /// Thêm nhân viên thành công
        /// </summary>
        [Test]
        public void CreateEmployee_Employee_ReturnSuccess()
        {
            // Arrange - Chuẩn bị dữ liệu đầu vào và kết quả mong muốn
            var employee = new Employee()
            {
                EmployeeCode = "NV020", 
                EmployeeName = "Nguyễn Đăng Duy",
                DepartmentID = new Guid("11452b0c-768e-5ff7-0d63-eeb1d8ed8cef"),
            };
            var fakeBaseDL = Substitute.For<IBaseDL<Employee>>();
            fakeBaseDL.CreateRecord(employee).Returns(0);
            var baseBL = new BaseBL<Employee>(fakeBaseDL);
            var expectedResult = (int)StatusResponse.Done;

            // Act - Gọi vào hàm cần test
            var actualResult = baseBL.CreateRecord(employee);

            // Assert - Kiểm tra kết quả mong muốn và kết quả thực tế
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Thêm nhân viên thất bại (bỏ trống trường Tên/Mã nhân viên)
        /// </summary>
        [Test]
        public void CreateEmployee_EmptyField_ReturnError()
        {
            // Arrange - Chuẩn bị dữ liệu đầu vào và kết quả mong muốn
            var employee = new Employee()
            {
                EmployeeCode = "NV020",
                EmployeeName = "",
                DepartmentID = new Guid("11452b0c-768e-5ff7-0d63-eeb1d8ed8cef"),
            };
            var fakeBaseDL = Substitute.For<IBaseDL<Employee>>();
            fakeBaseDL.CreateRecord(employee).Returns(1);

            var baseBL = new BaseBL<Employee>(fakeBaseDL);
            var expectedResult = (int)StatusResponse.Invalid;

            // Act - Gọi vào hàm cần test
            var actualResult = baseBL.CreateRecord(employee);

            // Assert - Kiểm tra kết quả mong muốn và kết quả thực tế
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}