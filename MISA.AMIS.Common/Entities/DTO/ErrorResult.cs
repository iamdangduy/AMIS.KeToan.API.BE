using MISA.AMIS.Common.Enums;

namespace MISA.AMIS.Common.Entities
{
    public class ErrorResult
    {
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public AmisErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Thông báo lỗi cho dev
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// thông báo lỗi cho người dùng
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// thêm thông tin về lỗi
        /// </summary>
        public object MoreInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TraceId { get; set; }



    }
}
