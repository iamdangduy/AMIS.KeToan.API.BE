using MISA.AMIS.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion
    }
}
