using MISA.AMIS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL
{
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        /// <summary>
        /// Trả về mã lớn nhất
        /// </summary>
        /// <returns>Mã lớn nhất</returns>
        /// Created by: NDDuy (05/01/2023)
        public string GetMaxEmployeeCode();
    }
}
