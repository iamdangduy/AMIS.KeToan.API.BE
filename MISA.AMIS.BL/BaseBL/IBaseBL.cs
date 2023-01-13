using MISA.AMIS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.BL
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Hàm validate dữ liệu
        /// </summary>
        /// <param name="record">Dữ liệu đầu vào</param>
        /// <returns>Đối tượng service mô tả thành công hoặc thất bại</returns>
        /// CreatedBy: NDDuy (13/1/2023)
        public ServiceResponse ValidateData(T record);

        /// <summary>
        /// Hàm sửa một nhân viên
        /// </summary>
        /// <param name="recordID">Id của nhân viên cần sửa</param>
        /// <returns>mã nhân viên vừa sửa</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        public int UpdateRecord(Guid recordID, T newRecord);

        /// <summary>
        /// Hàm thêm mới bản ghi
        /// </summary>
        /// <param name="newRecord">Thông tin của bản ghi cần thêm mới</param>
        /// CreatedBy: NDDuy (05/01/2023)
        public int CreateRecord(T newRecord);

        /// <summary>
        /// Hàm lấy bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>Chi tiết 1 bản ghi</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        public T GetRecordByID(Guid recordID);

        /// <summary>
        /// Hàm lấy tất cả bản ghi
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        public IEnumerable<T> GetAllRecord();

        /// <summary>
        /// Hàm xoá một bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>ID bản ghi đã xoá</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        public T DeleteRecordByID(Guid recordID);
    }
}
