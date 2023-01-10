using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common.Entities;

namespace MISA.AMIS.KeToan.API.Controllers
{
    public class DepartmentsController : BasesController<Department>
    {
        public DepartmentsController(IBaseBL<Department> baseBL) : base(baseBL)
        {

        }
    }
}
