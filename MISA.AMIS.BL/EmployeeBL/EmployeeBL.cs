using MISA.AMIS.Common.Entities;
using MISA.AMIS.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region Field

        private IEmployeeDL _employeeDL;

        #endregion

        #region Constructor

        public EmployeeBL(IEmployeeDL employeeDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
        }

        #endregion

        #region Method
        
        /// <summary>
        /// Hàm lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// Created by: NDDuy (05/01/2023)
        public string GetNewCode()
        {
            return _employeeDL.GetNewCode();
        } 

        #endregion
    }
}
