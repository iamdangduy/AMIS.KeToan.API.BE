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
        /// Lấy mã mới
        /// </summary>
        /// <returns>Mã mới</returns>
        /// Created by: NDDuy (05/01/2023)
        string GetNewCode();
    }
}
