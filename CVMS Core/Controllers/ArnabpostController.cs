using CVMSCore.BAL.Models;
using CVMSCore.BAL.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CVMS_Core.Controllers
{
    public class ArnabpostController : Controller
    {
        Postservice service = new Postservice();
        Myservice _myserviece = new Myservice();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            return View();
        }




        public JsonResult Savemployee(IFormCollection formcollection)
        {
            var result = 0;
            if (formcollection != null)
            {
                Mymodel obj = new Mymodel();//model object.........             // obj.EmpIdd = Convert.ToInt32(formcollection["EmpIdd"]);
                obj.Name = Convert.ToString(formcollection["Name"]);
                obj.Lastname = Convert.ToString(formcollection["Lastname"]);
                obj.Address = Convert.ToString(formcollection["Address"]);

                result = service.AddEmpSer(obj);
            }
            return Json(new { result });

        }

        public JsonResult getemployeelist()
        {
            List<Mymodel> employees = new List<Mymodel>();
            employees = _myserviece.GetList();
            return Json(new { employees = employees });
        }
    }
}
