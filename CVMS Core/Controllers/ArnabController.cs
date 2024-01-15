using CVMSCore.BAL.Models;
using CVMSCore.BAL.Service;
using Microsoft.AspNetCore.Mvc;

namespace CVMS_Core.Controllers
{
    public class ArnabController : Controller
    {
        Myservice _myserviece = new Myservice();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData()
        {
            return View();
        }
        public JsonResult GetEmployeeList()
        {
            List<Mymodel> employees = new List<Mymodel>();
            employees = _myserviece.GetList();
            return Json(new { employees = employees });
        }
    }
}
