using MISA.AMIS.Common;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.AMIS.Common.MISAAttributes;

namespace MISA.AMIS.BL
{
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Hàm thêm mới bản ghi
        /// </summary>
        /// <param name="newRecord">Thông tin của bản ghi cần thêm mới</param>
        public int CreateRecord(T newRecord)
        {

            return _baseDL.CreateRecord(newRecord);
        }

        /// <summary>
        /// Hàm xoá bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>ID bản ghi đã xoá</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        public T DeleteRecordByID(Guid recordID)
        {
            return _baseDL.DeleteRecordByID(recordID);
        }

        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        public IEnumerable<T> GetAllRecord()
        {
            return _baseDL.GetAllRecord();
        }

        /// <summary>
        /// Hàm lấy bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>Chi tiết 1 bản ghi</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        public T GetRecordByID(Guid recordID)
        {
            return _baseDL.GetRecordByID(recordID);
        }

        /// <summary>
        /// Hàm sửa một nhân viên
        /// </summary>
        /// <param name="recordID">Id của nhân viên cần sửa</param>
        /// <returns>mã nhân viên vừa sửa</returns>
        public int UpdateRecord(Guid recordID, T newRecord)
        {
            return _baseDL.UpdateRecord(recordID, newRecord);
        }


        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="record">Dữ liệu đầu vào</param>
        /// <returns>Đối tượng service mô tả thành công hoặc thất bại</returns>
        /// CreatedBy: NDDuy (13/1/2023)
        public ServiceResponse ValidateData(T record)
        {
            var errorMessages = new List<string>();

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(record);

                var isNotNullOrEmptyAttribute = (IsNotNullOrEmptyAttribute?)Attribute.GetCustomAttribute(property, typeof(IsNotNullOrEmptyAttribute));
                if (isNotNullOrEmptyAttribute != null && string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    errorMessages.Add(isNotNullOrEmptyAttribute.ErrorMessage);
                }

                if (errorMessages.Count > 0)
                {
                    return new ServiceResponse
                    {
                        Success = (int)StatusResponse.Invalid,
                        Data = new ErrorResult
                        {
                            ErrorCode = AmisErrorCode.InsertFailed,
                            DevMsg = Resource.DevMsg_InvalidInput,
                            UserMsg = Resource.UserMsg_InvalidInput,
                            MoreInfo = errorMessages.ToArray(),
                        }
                    };
                }

            }
            return new ServiceResponse { Success = (int)StatusResponse.Done };

        }

        #endregion
    }
}
