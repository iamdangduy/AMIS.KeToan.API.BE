using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common
{
    /// <summary>
    /// Phản hồi người dùng
    /// </summary>
    /// CreatedBy: NDDuy (13/1/2023)
    public class ServiceResponse
    {
        /// <summary>
        /// Thành công hoặc thất bại
        /// </summary>
        public int Success { get; set; }

        /// <summary>
        /// Data response khi thành công hoặc thất bại
        /// </summary>
        public object? Data { get; set; }
    }
}
