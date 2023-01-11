using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Common
{
    public class MISAAttributes
    {

        /// <summary>
        /// Attribute dùng để xác định 1 property là khóa chính 
        /// </summary>
        /// Modified by: NDDuy 6/1/2023
        [AttributeUsage(AttributeTargets.Property)]
        public class PrimaryKeyAttribute : Attribute
        {

        }

        /// <summary>
        /// Attribute dùng để xác định 1 property là mã
        /// </summary>
        /// Modified by: NDDuy 6/1/2023
        [AttributeUsage(AttributeTargets.Property)]
        public class CodeAttribute : Attribute
        {

        }


        /// <summary>
        /// Attribute dùng để xác định 1 property là email
        /// </summary>
        /// Modified by: NDDuy 6/1/2023
        [AttributeUsage(AttributeTargets.Property)]
        public class EmailAttribute : Attribute
        {

        }


        /// <summary>
        /// Attribure dùng để xác định 1 property không được để trống
        /// </summary>    
        /// Modified by: NDDuy 6/1/2023
        [AttributeUsage(AttributeTargets.Property)]
        public class IsNotNullOrEmptyAttribute : Attribute
        {
            #region Field
            /// <summary>
            /// Message lỗi trả về cho client
            /// </summary>
            /// Modified by: NDDuy 6/1/2023
            public string ErrorMessage;
            #endregion

            #region Constructor
            public IsNotNullOrEmptyAttribute(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
            #endregion
        }
    }
}
