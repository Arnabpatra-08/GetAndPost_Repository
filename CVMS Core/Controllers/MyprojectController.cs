using CVMSCore.BAL.Models.Car_model;
using CVMSCore.BAL.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Diagnostics;
using System.IO;

namespace CVMS_Core.Controllers
{
    public class MyprojectController : BaseController

    {
        Carservice _myserviece = new Carservice();
        public IActionResult Index()
        {
            return View();
        }

        //************************************* view for the home page ********************************
        public IActionResult Myhomepage()
        {
            return View();
        }

        //******************************* view for Admin log in ********************************************
        public IActionResult AdminLogin()
        {
            return View();
        }
        //************************************* Method for admin login loin ***********************************************

        [HttpPost]
        public IActionResult AdminLoginPage(Adminlogin model)
        {
            if (ModelState.IsValid)
            {
                var result = _myserviece.AdminLogSer(model);

                if (result == 1)
                {
                    ViewBag.ReturnMessage = "Login successfull...";

                    return RedirectToAction("AdminDashbord", "Myproject");
                    //ViewBag.ReturnMessage = "Login successfull";
                }
                else
                {
                    ViewBag.ReturnMessage = "Invalid credentials Please Enter Correct Username Or Password";
                    return View("AdminLogin", model);
                }
            }

            return View("AdminLogin", model);
        }


        //***************************Admin Dash Borad*******************************************
        public IActionResult AdminDashbord(string LoggedInName)
        {
            ViewBag.LoggedInName = LoggedInName;
            return View();
        }

        //************************ view for get seller details************************************
        public IActionResult Adminviewpage()
        {
            return View();
        }

        //************************** view for get buyer details ***********************************
        public IActionResult AdminhomeBuyer() 
        {
            return View();
        }


        //*************************** view for customer sign up ********************************************
        public IActionResult CustomerSignuppage()
        {
            return View();
        }

        //********************* method for customer signup *********************************************************
        public IActionResult SellSignUpPage(SellerSignUp model)
        {
            if (ModelState.IsValid)
            {
                // Check if passwords match
                if (model.Passward != model.ComfirmPassward)
                {
                    ViewBag.ReturnMessage = "Password and Confirm Password do not match.";
                    return View("CustomerSignuppage", model);
                }

                var result = _myserviece.SellsignupSer(model);

                if (result == 101)
                {
                    ViewBag.ReturnMessage = "Congrats SignUp successfull!!!";
                    return RedirectToAction("AdminLogin", "Myproject");
                }
                else
                {
                    ViewBag.ReturnMessage = "Invalid credentials";
                    return View("CustomerSignuppage", model);
                }
            }

            // If ModelState is not valid, return the view with validation errors
            return View("CustomerSignuppage", model);
        }

        public IActionResult Customerhomepage()
        {
            return View();
        }
        public IActionResult Buyerhomepage()
        {
            return View();
        }
        public IActionResult Sellerhomepage()
        {
            return View();
        }

        //***************************************************save seller details***************************************************
        public JsonResult Savecustomerselldetails(IFormCollection formcollection)
        {
            int result = 0;
            // var files = Request.Form.Files[0];
            IFormFile fileInput1 = Request.Form.Files[0];

            IFormFile file = Request.Form.Files[0];
            string filename = "";
            //string filename2 = "";

            //string filepath1 = "";
            string filepath2 = "";

            string savefile = "";

            if (formcollection != null && file != null && fileInput1 != null && file.Length > 0 && fileInput1.Length > 0)
            {
                sellerformdata emp = new sellerformdata();
                emp.Name = Convert.ToString(formcollection["Name"]);
                emp.Moblieno = Convert.ToString(formcollection["Moblieno"]);

                emp.Country = Convert.ToString(formcollection["Country"]);
                emp.State = Convert.ToString(formcollection["State"]);
                emp.City = Convert.ToString(formcollection["City"]);
                emp.CarModel = Convert.ToString(formcollection["CarModel"]);
                emp.CarPrice = Convert.ToString(formcollection["CarPrice"]);
                emp.CompanyName = Convert.ToString(formcollection["CompanyName"]);
                emp.CarColor = Convert.ToString(formcollection["CarColor"]);
                emp.UsageYears = Convert.ToString(formcollection["UsageYears"]);
                emp.CarCondition = Convert.ToString(formcollection["CarCondition"]);
                emp.Mileage = Convert.ToString(formcollection["Mileage"]);
                emp.Remarks = Convert.ToString(formcollection["Remarks"]);


                filename = file.FileName;
               
                filepath2 = Path.Combine("~/Arnabfile/", filename);


                result = _myserviece.savesellerform(emp, filepath2);


            }
            return Json(new { result = result });
        }


        //***************************methods for binding data for country, state  and city**************************
        public JsonResult getcountryname()
        {
            List<Newcountry> bcountry = new List<Newcountry>();
            bcountry = _myserviece.GetcountryList();
            return Json(new { bcountry = bcountry });
        }

        public JsonResult getstatename(int CountryId)
        {
            List<Newstate> bstate = new List<Newstate>();
            bstate = _myserviece.GetstateList(CountryId);
            return Json(new { bstate = bstate });
        }

        public JsonResult getcityname(int StateId)
        {
            List<Newcity> bcity = new List<Newcity>();
            bcity = _myserviece.GetcityList(StateId);
            return Json(new { bcity = bcity });
        }

        //****************************get sell all list**********************************

        public JsonResult getallselllist()
        {
            List<sellerformdata> sell = new List<sellerformdata>();
            sell = _myserviece.GetsellList();
            return Json(new { sell = sell });
        }


        //************************************ delete seller dtl*************************
        public JsonResult Deletesellerdata(int Id)
        {
            try
            {
                int result = _myserviece.Deletesellerdata(Id);

                if (result > 0)
                {
                    return Json(new { success = true, message = "Seller Details deleted successfully" });
                }
                else
                {
                    return Json(new { success = false, message = "Seller not found" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while deleting the seller" });
            }
        }

        //****************************get Buy all list***********************************

        public JsonResult getallbuylist()
        {
            List<sellerformdata> buy = new List<sellerformdata>();
            buy = _myserviece.GetbuyList();
            return Json(new { buy = buy });
        }

        //******************************************************************************
        [HttpGet]
        public JsonResult viewdetails(int Id)
        {
            List<sellerformdata> company = new List<sellerformdata>();
            //Newcity company = new Newcity();
            try
            {
                company = _myserviece.EditCompanyById(Id);
            }
            catch (Exception ex)
            {

            }
            return Json(new { company = company });


        }


        [HttpGet]
        public JsonResult buyerdetails(int Id)
        {
            List<sellerformdata> bdetail = new List<sellerformdata>();
            //Newcity company = new Newcity();
            try
            {
                bdetail = _myserviece.BuyerDltById(Id);
            }
            catch (Exception ex)
            {

            }
            return Json(new { bdetail = bdetail });


        }

        //************************************************** save buyer dtl *********************************************************

        public JsonResult Savebuyerdtl(IFormCollection formcollection)
        {
            var result = 0;
            if (formcollection != null)
            {
                sellerformdata emp = new sellerformdata();
                emp.Name = Convert.ToString(formcollection["Name"]);
                emp.Moblieno = Convert.ToString(formcollection["Moblieno"]);
                emp.BuyerName = Convert.ToString(formcollection["BuyerName"]);
                emp.BuyerMoblieno = Convert.ToString(formcollection["BuyerMoblieno"]);

                emp.Country = Convert.ToString(formcollection["Country"]);
                emp.State = Convert.ToString(formcollection["State"]);
                emp.City = Convert.ToString(formcollection["City"]);
                emp.CarModel = Convert.ToString(formcollection["CarModel"]);
                emp.CarPrice = Convert.ToString(formcollection["CarPrice"]);
                emp.CompanyName = Convert.ToString(formcollection["CompanyName"]);
                emp.CarColor = Convert.ToString(formcollection["CarColor"]);
                emp.UsageYears = Convert.ToString(formcollection["UsageYears"]);
                emp.CarCondition = Convert.ToString(formcollection["CarCondition"]);
                emp.Mileage = Convert.ToString(formcollection["Mileage"]);
                emp.Remarks = Convert.ToString(formcollection["Remarks"]);


                

                result = _myserviece.savebuyerform(emp);


            }
            return Json(new { result = result });
        }

        //********************************* view for seller dash board ******************************************** 
        public IActionResult SellerDashBoradPage(String LoggedInName)
        {
            ViewBag.LoggedInName = LoggedInName;

            return View();
        }
        //public JsonResult SellerDashBorad(string UserName, string Passward)
        //{
        //    try
        //    {
        //        if (UserName != null && Passward != null)
        //        {
        //            var result = _myserviece.customerdashser(UserName, Passward);

        //            if (result != null && result.Count > 0)
        //            {
        //                return Json(new { success = true, customerDetails = result });
        //            }
        //            else
        //            {
        //                return Json(new { success = false, message = "Invalid credentials" });
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { success = false, message = "Invalid input" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it accordingly
        //        return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
        //    }
        //}


        //*******************************************************************

        //public JsonResult SellerDashBorad(string UserName, string Passward)
        //{
        //    try
        //    {
        //        if (UserName != null && Passward != null)
        //        {
        //            var result = _myserviece.customerdashser(UserName, Passward);

        //            if (result != null && result.Count > 0 && result[0].IsValidCredentials) // Add a check for valid credentials
        //            {
        //                return Json(new { success = true, customerDetails = result });
        //            }
        //            else
        //            {
        //                return Json(new { success = false, message = "Invalid credentials" });
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { success = false, message = "Invalid input" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it accordingly
        //        return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
        //    }
        //}

        //*************************************** mehod for customer login and dashboard*************************
        public JsonResult SellerDashBorad(string UserName, string Passward)
        {
            try
            {
                if (UserName != null && Passward != null)
                {
                    var result = _myserviece.customerdashser(UserName, Passward);

                    if (result != null && result.Count > 0)
                    {
                            return Json(new { success = true, customerDetails = result });

                    }
                    else
                    {
                        return Json(new { success = false, message = "Invalid credentials" });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Invalid input" });
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }


        //****************************************log in******************************************
        public IActionResult login(string UserName, string Password)
        {
            UserLogin userdt = new UserLogin();
            List<UserLogin> userdtt = new List<UserLogin>();
            if (UserName != null && Password != null)
            {
                userdt = _myserviece.AdminLogSer(UserName, Password);
                if (userdt != null)
                {
                    HttpContext.Session.SetString("LoggedUserInfo", JsonConvert.SerializeObject(userdt));
                    var value = HttpContext.Session.GetString("LoggedUserInfo");
                    //string _userDetail = Security.GetEncryptString(userdt.UserName.Trim() + "|" + encryptPassword.Trim());
                    ViewBag.LoggedInName = userdt.LoggedInName;
                    userdt = GetUserDetail();
                }

                if (userdt != null)
                {
                    if (userdt.UserSubType == "Admin")
                    {

                        return RedirectToAction("AdminDashbord", "Myproject", new { LoggedInName = userdt.LoggedInName });
                    }
                    else if (userdt.UserSubType == "Customer")
                    {

                        return RedirectToAction("SellerDashBoradPage", "Myproject", new { LoggedInName = userdt.LoggedInName});
                    }
                   
                }
                //if(userdt != null)
                //{
                //    HttpContext.Session.SetString("LoggedUserInfo", JsonConvert.SerializeObject(userdt));
                //    var value = HttpContext.Session.GetString("LoggedUserInfo");
                //    //string _userDetail = Security.GetEncryptString(userdt.UserName.Trim() + "|" + encryptPassword.Trim());
                //    userdt = GetUserDetail();
                //}

                //-----------------------------
                //ModelState.AddModelError("", "Invalid username or password");
                //return View();
                ViewData["ErrorMessage"] = "Invalid username or password";
                return View("AdminLogin");
            }
            else
            {

                return View();
            }
        }

        //********************************* for user wise get ************************************
        public JsonResult CustomerStatus(string LoggedInName)
        {
            List<sellerformdata> Pat = new List<sellerformdata>();
            Pat = _myserviece.GetCustomerStatusSer(LoggedInName);
            return Json(Pat);

        }
        public IActionResult logout()

        {
            //Session.abandon();
            TempData.Clear();
            return RedirectToAction("AdminLogin", "Myproject");
        }

        public IActionResult ABVCD()
        {
            return View();
        }


        public IActionResult Chinaarsatrupa()
        {
            return View();
        }
        public IActionResult Arnab_ka_lover_Sukanya()
        {
            return View();
        }

    }
}
