using MISA.AMIS.Common.Entities;


namespace MISA.AMIS.DL
{
    public interface IEmployeeDL : IBaseDL<Employee>
    {
        /// <summary>
        /// Trả về mã lớn nhất
        /// </summary>
        /// <returns>Mã lớn nhất</returns>
        /// Created by: NDDuy (05/01/2023)
        public string GetMaxEmployeeCode();

    }
}
