using CVMSCore.BAL.Models.Car_model;
using CVMSCore.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVMSCore.BAL.Service
{
    public class Carservice
    {
        Carrepo _repo = new Carrepo();

        //************************* admin login service************************************
        public int AdminLogSer(Adminlogin obj)
        {
            return _repo.AdminLoginRepository(obj);
        }

        //***********************seller sign Up service*************************************
        public int SellsignupSer(SellerSignUp obj)
        {
            return _repo.SellSignupRepository(obj);
        }

        //***********************seller LogIn service*************************************
        //public int SellloginSer(selerlogin obj)
        //{
        //    return _repo.SellLoginRepository(obj);
        //}

        //***********************Buy sign Up service*************************************
        public int BuysignupSer(BuySignUp obj)
        {
            return _repo.BuySignupRepository(obj);
        }

        //***********************Buy LogIn service*************************************
        public int BuyloginSer(Buylogin obj)
        {
            return _repo.BuyLoginRepository(obj);
        }

        //**********************************for save data******************************
        public int savesellerform(sellerformdata emp, string filepath2)
        {
            int num = 102;
            try
            {
                return _repo.savesellerform(emp, filepath2);


            }
            catch
            {

            }
            return num;
        }


        public List<Newcountry> GetcountryList()
        {
            List<Newcountry> list = new List<Newcountry>();
            list = _repo.GetcountryData();

            return list;
        }
        public List<Newstate> GetstateList(int CountryId)
        {
            List<Newstate> list = new List<Newstate>();
            list = _repo.GetstateData(CountryId);

            return list;
        }

        public List<Newcity> GetcityList(int StateId)
        {
            List<Newcity> list = new List<Newcity>();
            list = _repo.GetcityData(StateId);

            return list;
        }

        //**************************************get seller dtl************************************
        public List<sellerformdata> GetsellList()
        {
            List<sellerformdata> list = new List<sellerformdata>();
            list = _repo.GetsellData();

            return list;
        }

        //**********************************delete seller dtl ser*******************************

        public int Deletesellerdata(int Id)
        {
            try
            {
                return _repo.DeletesellerlistById(Id);
            }
            catch (Exception ex)
            {
                //Handle exceptions and log them
                throw ex;
            }
        }

        //*************************************det buyer dtl*************************************
        public List<sellerformdata> GetbuyList()
        {
            List<sellerformdata> list = new List<sellerformdata>();
            list = _repo.GetbuyData();

            return list;
        }

        //****************************************************************************************
        public List<sellerformdata> EditCompanyById(int Id)
        {
            List<sellerformdata> company = new List<sellerformdata>();
            try
            {
                return _repo.EditCompanyById(Id);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log them
                throw ex;
            }
        }

        //************************************* service for add buyer detl ***************************************************
        public List<sellerformdata> BuyerDltById(int Id)
        {
            List<sellerformdata> company = new List<sellerformdata>();
            try
            {
                return _repo.BuyerdtllistById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //*******************************************for save buyer data****************************************

        public int savebuyerform(sellerformdata emp)
        {
            int num = 102;
            try
            {
                return _repo.savebuyerformlist(emp);


            }
            catch
            {

            }
            return num;
        }


        //*****************************************************
        public List<Buylogin> customerdashser(string UserName, string Passward)
        {
            List<Buylogin> ls = new List<Buylogin>();
            ls = _repo.customerdashRepo(UserName, Passward);
            return ls;
        }



        //*******************************************************
        public UserLogin AdminLogSer(string UserName, string Password)
        {
            return _repo.AdminLoginRepo(UserName, Password);
        }

        //****************************************************** 
        public List<sellerformdata> GetCustomerStatusSer(string LoggedInName)
        {
            List<sellerformdata> ls = new List<sellerformdata>();
            ls = _repo.customerStatusRepo(LoggedInName);
            return ls;
        }
    }
}
