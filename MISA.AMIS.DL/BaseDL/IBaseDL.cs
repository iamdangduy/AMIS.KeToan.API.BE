using MISA.AMIS.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.DL
{
    public interface IBaseDL<T>
    {
        /// <summary>
        /// Hàm lấy bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>Chi tiết 1 bản ghi</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        T GetRecordByID(Guid recordID);

        /// <summary>
        /// Hàm lấy tất cả bản ghi theo ID
        /// </summary>
        /// <returns>Tất cả bản ghi</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        IEnumerable<T> GetAllRecord();

        /// <summary>
        /// Hàm xoá bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <returns>ID bản ghi đã xoá</returns>
        /// CreatedBy: NDDuy (05/01/2023)
        T DeleteRecordByID(Guid recordID);

        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="newRecord">Thông tin bản ghi cần thêm mới</param>
        int CreateRecord(T newRecord);

        /// <summary>
        /// Hàm sửa một nhân viên
        /// </summary>
        /// <param name="recordID">Id của nhân viên cần sửa</param>
        /// <returns>mã nhân viên vừa sửa</returns>
        int UpdateRecord(Guid recordID, T newRecord);
    }
}
