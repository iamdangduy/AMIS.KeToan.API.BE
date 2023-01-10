using MISA.AMIS.Common.Entities;
using MISA.AMIS.DL;
using MISA.AMIS.DL.ConnectionDL;

namespace MISA.AMIS.KeToan.EmployeeTest
{
    public class EmployeesControllerTest
    {
        #region Field
        //private IEmployeeDL _employeeDL = new IEmployeeDL(new TestConnectionDL());
        #endregion

        /// <summary>
        /// Hàm test nếu độ dài dữ liệu vượt quá mong đợi
        /// </summary>
        [Test]
        public void CreateEmployee_BigLength_Returns400BadRequest()
        {
            //// Arrange - Chuẩn bị dữ liệu đầu vào và kết quả mong muốn
            //var testEmployee = new Employee();

            //Employee e = new Employee();
            //e.EmployeeCode = "NV022222222222222222222222222222222222222222222222222022222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222";
            //e.EmployeeName = "";
            //e.DepartmentID = new Guid("7686595d-16d5-33b3-0080-e8e2a817c80e");
            

            //int expectedResult = 400;

            //// Act - Gọi vào hàm cần test
            //int actualResult = testEmployee.InsertEmployee(e);

            //// Assert - Kiểm tra kết quả mong muốn và kết quả thực tế
            //Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Hàm test nếu độ dài dữ liệu vượt quá mong đợi
        /// </summary>
        [Test]
        public void CreateEmployee_DuplicatedValue_Returns400BadRequest()
        {

        }
    }
}