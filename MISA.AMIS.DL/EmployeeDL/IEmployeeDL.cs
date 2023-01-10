using MISA.AMIS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public interface IEmployeeDL : IBaseDL<Employee>
    {
        /// <summary>
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// Created by: NDDuy (05/01/2023)
        public string GetNewCode();

        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="newEmployee">Thông tin nhân viên</param>
        /// <returns>ID của nhân viên vừa thêm mới</returns>
        /// Createdby: NDDuy (10/01/2023)
        //public int CreatedEmployee(Employee newEmployee);

    }
}
