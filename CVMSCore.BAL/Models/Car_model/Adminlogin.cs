using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVMSCore.BAL.Models.Car_model
{
    public class Adminlogin
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Passward { get; set; }

    }

    public class SellerSignUp
    {
        public int SellerId { get; set; }
       
        [RegularExpression(@"^[A-Z][a-z]* [A-Z][a-z]*$", ErrorMessage = "Username should start with a capital letter and title should start with a capital letter.")]

        public string UserName { get; set; }
        public string Passward { get; set; }
        public string ComfirmPassward { get; set; }

    }

    public class selerlogin
    {
        public string UserName { get; set; }
        public string Passward { get; set; }

    }

    public class BuySignUp
    {
        public int BuyId { get; set; }

        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string Passward { get; set; }
        public string ComfirmPassward { get; set; }

    }

    public class Buylogin
    {
        public string UserName { get; set; }
        public string Passward { get; set; }
        public string Countryname { get; set; }
        public string Statename { get; set; }
        public string Cityname { get; set; }
        public string CarModel { get; set; }
        public string CarPrice { get; set; }
        public string CompanyName { get; set; }
        public string CarColor { get; set; }
        public string UsageYears { get; set; }
        public string CarCondition { get; set; }
        public string Mileage { get; set; }
        public string Remarks { get; set; }
        public string filepath2 { get; set; }
        public string name { get; set; }
        public string moblieno { get; set; }

        public string BuyerName { get; set; }
        public string BuyerMoblieno { get; set; }

    }

    public class sellerformdata
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public string Countryname { get; set; }
        public string Statename { get; set; }
        public string Cityname { get; set; }
        public string CarModel { get; set; }
        public string CarPrice { get; set; }
        public string CompanyName { get; set; }
        public string CarColor { get; set; }
        public string UsageYears { get; set; }
        public string CarCondition { get; set; }
        public string Mileage { get; set; }
        public string Remarks { get; set; }
        public string filepath2 { get; set; }
        public string Name { get; set; }
        public string Moblieno { get; set; }

        public string BuyerName { get; set; }
        public string BuyerMoblieno { get; set; }

    }


    public class Buyerformdata
    {
        public int BuyerId { get; set; }
        public string Countryname { get; set; }
        public string Statename { get; set; }
        public string Cityname { get; set; }
        public string CarModel { get; set; }
        public string CarPrice { get; set; }
        public string CompanyName { get; set; }
        public string CarColor { get; set; }
        public string UsageYears { get; set; }
        public string CarCondition { get; set; }
        public string Mileage { get; set; }
        public string Remarks { get; set; }
        public string Name { get; set; }
        public string Moblieno { get; set; }

    }

    public class Newcountry
    {
        public int CountryId  { get; set; }
        public string Countryname { get; set; }

    }

    public class Newstate
    {
        public int StateId { get; set; }
        public string Statename { get; set; }

    }

    public class Newcity
    {
        public int CityId { get; set; }
        public string Cityname { get; set; }

    }


    public class UserLogin
    {
        public int Userid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public string UserSubType { get; set; }
        public int IsAuthenticated { get; set; }
        public string LoggedInName { get; set; }

    }


}
