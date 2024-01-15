using CVMSCore.BAL.Models.Car_model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVMSCore.BAL.Repository
{
    public class Carrepo
    {
        private SqlConnection _conn;  //for sql connection
        private DapperConnection dapper = new DapperConnection(ConnectionFile.Connection_ANTSDB);


        //********************************** *for  admin Authentication ***********************************************************************
        public int AdminLoginRepository(Adminlogin obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Passward", obj.Passward);
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("SAF_Adminlogin", dynamicParameters, commandType: CommandType.StoredProcedure );
            DapperConnection.CloseConnection(this._conn);

            return result;

        }
        //***********************************for  Seller Autherigation ***********************************************************************

        public int SellSignupRepository(SellerSignUp obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Passward", obj.Passward);
            dynamicParameters.Add("@ComfirmPassward", obj.ComfirmPassward);

            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("SAF_SellerName", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //***********************************for  Seller Log in  ***********************************************************************

        //public int SellLoginRepository(selerlogin obj)
        //{
        //    DynamicParameters dynamicParameters = new DynamicParameters();
           
        //    dynamicParameters.Add("@UserName", obj.UserName);
        //    dynamicParameters.Add("@Passward", obj.Passward);
        

        //    this._conn = this.dapper.GetConnection();
        //    DapperConnection.OpenConnection(this._conn);
        //    SqlConnection conn = this._conn;
        //    var result = conn.QueryFirstOrDefault<int>("SAF_sellerloginproc", dynamicParameters, commandType: CommandType.StoredProcedure);
        //    DapperConnection.CloseConnection(this._conn);

        //    return result;

        //}


        //***********************************for  Buy Autherigation ***********************************************************************

        public int BuySignupRepository(BuySignUp obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CustomerName", obj.CustomerName);
            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Passward", obj.Passward);
            dynamicParameters.Add("@ComfirmPassward", obj.ComfirmPassward);

            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("SAF_BuyName", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //***********************************for  Buier Log in  ***********************************************************************

        public int BuyLoginRepository(Buylogin obj)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();

            dynamicParameters.Add("@UserName", obj.UserName);
            dynamicParameters.Add("@Passward", obj.Passward);


            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            var result = conn.QueryFirstOrDefault<int>("SAF_Buyloginproc", dynamicParameters, commandType: CommandType.StoredProcedure);
            DapperConnection.CloseConnection(this._conn);

            return result;

        }

        //************************ for save seller details*************************************************

        public int savesellerform(sellerformdata emp, string filepath2)
        {
            int num = 0;
            try
            {
                // byte[] fileData = File.ReadAllBytes(filepath);

                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("Name", (object)emp.Name, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("Moblieno", (object)emp.Moblieno, new DbType?(), new ParameterDirection?(), new char?(), new byte?(), new byte?());

                dynamicParameters1.Add("Country", (object)emp.Country, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("State", (object)emp.State, new DbType?(), new ParameterDirection?(), new char?(), new byte?(), new byte?());
                dynamicParameters1.Add("City", (object)emp.City, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CarModel", (object)emp.CarModel, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CarPrice", (object)emp.CarPrice, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CompanyName", (object)emp.CompanyName, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CarColor", (object)emp.CarColor, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("UsageYears", (object)emp.UsageYears, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CarCondition", (object)emp.CarCondition, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("Mileage", (object)emp.Mileage, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("Remarks", (object)emp.Remarks, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());

                dynamicParameters1.Add("filepath2", filepath2);

                this._conn = this.dapper.GetConnection();
                DapperConnection.OpenConnection(this._conn);
                SqlConnection conn = this._conn;
                DynamicParameters dynamicParameters2 = dynamicParameters1;
                CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
                int? nullable2 = new int?();
                CommandType? nullable3 = nullable1;
                string? str = SqlMapper.ExecuteScalar((IDbConnection)conn, "SAF_savecardetails", (object)dynamicParameters2, (IDbTransaction)null, nullable2, nullable3).ToString();
                DapperConnection.CloseConnection(this._conn);
                num = Convert.ToInt32(str);

            }
            catch (Exception exx)
            {

            }

            return num;



        }


        public List<Newcountry> GetcountryData()   //list creating using the controller method GetData
        {
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            List<Newcountry> store = new List<Newcountry>();
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            DynamicParameters dynamicParameters2 = dynamicParameters1;
            CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
            // int? nullable2 = new int?();
            CommandType? nullable3 = nullable1;
            store = _conn.Query<Newcountry>("SAF_bindcountry", commandType: CommandType.StoredProcedure).ToList();
            DapperConnection.CloseConnection(this._conn);
            //int num = Convert.ToInt32(str);
            return store;
        }


        public List<Newstate> GetstateData(int CountryId)   //list creating using the controller method GetData
        {
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            List<Newstate> store = new List<Newstate>();
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            DynamicParameters dynamicParameters2 = dynamicParameters1;
            CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
            // int? nullable2 = new int?();
            CommandType? nullable3 = nullable1;
            store = _conn.Query<Newstate>("SAF_bindstate",new { CountryId=CountryId}, commandType: CommandType.StoredProcedure).ToList();
            DapperConnection.CloseConnection(this._conn);
            //int num = Convert.ToInt32(str);
            return store;
        }


        public List<Newcity> GetcityData(int StateId)   //list creating using the controller method GetData
        {
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            List<Newcity> store = new List<Newcity>();
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            DynamicParameters dynamicParameters2 = dynamicParameters1;
            CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
            // int? nullable2 = new int?();
            CommandType? nullable3 = nullable1;
            store = _conn.Query<Newcity>("SAF_bindcity", new { StateId = StateId }, commandType: CommandType.StoredProcedure).ToList();
            DapperConnection.CloseConnection(this._conn);
            //int num = Convert.ToInt32(str);
            return store;
        }

        //*******************************************Get seller dtl ****************************************
        public List<sellerformdata> GetsellData()
        {
            List<sellerformdata> obj = new List<sellerformdata>();

            this._conn = this.dapper.GetConnection();

            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            obj = conn.Query<sellerformdata>("saf_getselldetails", commandType: CommandType.StoredProcedure).ToList();
            DapperConnection.CloseConnection(this._conn);

            return obj;
        }

        //*********************************************delete seller dtl repo*******************************

        public int DeletesellerlistById(int Id)
        {
            try
            {
                using (this._conn = dapper.GetConnection())
                {
                    DapperConnection.OpenConnection(this._conn);
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);

                    var result = _conn.Execute("Saf_sellerdtlDelete", parameters, commandType: CommandType.StoredProcedure);

                    DapperConnection.CloseConnection(this._conn);
                    return result; 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //******************************************* get buyer details ************************************
        public List<sellerformdata> GetbuyData()   
        {
            List<sellerformdata> obj = new List<sellerformdata>();   

            this._conn = this.dapper.GetConnection();   

            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            obj = conn.Query<sellerformdata>("saf_getbuydetails", commandType: CommandType.StoredProcedure).ToList();   
            DapperConnection.CloseConnection(this._conn);

            return obj;
        }

        //**************************************************************************************

        public List<sellerformdata> EditCompanyById(int Id)
        {
            List<sellerformdata> getlist = new List<sellerformdata>();
            try
            {
                using (this._conn = dapper.GetConnection())
                {
                    DapperConnection.OpenConnection(this._conn);
                    // Implement your retrieval logic using Dapper and a stored procedure here
                    // Example:
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    getlist = _conn.Query<sellerformdata>("saf_getviewdetails", parameters, commandType: CommandType.StoredProcedure).ToList();
                    DapperConnection.CloseConnection(this._conn);
                    //return employee;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and log them

            }
            return getlist;
        }


        public List<sellerformdata> BuyerdtllistById(int Id)
        {
            List<sellerformdata> getlist = new List<sellerformdata>();
            try
            {
                using (this._conn = dapper.GetConnection())
                {
                    DapperConnection.OpenConnection(this._conn);
                    // Implement your retrieval logic using Dapper and a stored procedure here
                    // Example:
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@Id", Id);
                    getlist = _conn.Query<sellerformdata>("saf_buydetailsgetdata", parameters, commandType: CommandType.StoredProcedure).ToList();
                    DapperConnection.CloseConnection(this._conn);
                    //return employee;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and log them

            }
            return getlist;
        }

        //********************************************** for save buyer data ************************************************************

        public int savebuyerformlist(sellerformdata emp)
        {
            int num = 0;
            try
            {

                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("Name", (object)emp.Name, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("Moblieno", (object)emp.Moblieno, new DbType?(), new ParameterDirection?(), new char?(), new byte?(), new byte?());
                dynamicParameters1.Add("BuyerName", (object)emp.BuyerName, new DbType?(), new ParameterDirection?(), new char?(), new byte?(), new byte?());
                dynamicParameters1.Add("BuyerMoblieno", (object)emp.BuyerMoblieno, new DbType?(), new ParameterDirection?(), new char?(), new byte?(), new byte?());

                dynamicParameters1.Add("Country", (object)emp.Country, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("State", (object)emp.State, new DbType?(), new ParameterDirection?(), new char?(), new byte?(), new byte?());
                dynamicParameters1.Add("City", (object)emp.City, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CarModel", (object)emp.CarModel, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CarPrice", (object)emp.CarPrice, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CompanyName", (object)emp.CompanyName, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CarColor", (object)emp.CarColor, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("UsageYears", (object)emp.UsageYears, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("CarCondition", (object)emp.CarCondition, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("Mileage", (object)emp.Mileage, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters1.Add("Remarks", (object)emp.Remarks, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());


                this._conn = this.dapper.GetConnection();
                DapperConnection.OpenConnection(this._conn);
                SqlConnection conn = this._conn;
                DynamicParameters dynamicParameters2 = dynamicParameters1;
                CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
                int? nullable2 = new int?();
                CommandType? nullable3 = nullable1;
                string? str = SqlMapper.ExecuteScalar((IDbConnection)conn, "SAF_savebuydetails", (object)dynamicParameters2, (IDbTransaction)null, nullable2, nullable3).ToString();
                DapperConnection.CloseConnection(this._conn);
                num = Convert.ToInt32(str);

            }
            catch (Exception exx)
            {

            }

            return num;



        }

        public List<Buylogin> customerdashRepo(string UserName, string Passward)
        {
            List<Buylogin> obj = new List<Buylogin>();

            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserName", UserName);
            dynamicParameters.Add("@Passward", Passward);

            obj = conn.Query<Buylogin>("GetBuyerDetailsForSeller", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();

            DapperConnection.CloseConnection(this._conn);
            return obj;
        }

        //*****************************************login******************************************

        public UserLogin AdminLoginRepo(string UserName, string Password)
        {
            UserLogin userDetail = null;

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@UserName", UserName);
                dynamicParameters.Add("@Password", Password);

                using (this._conn = this.dapper.GetConnection())
                {
                    DapperConnection.OpenConnection(this._conn);

                    userDetail = _conn.Query<UserLogin>("ValidateUserLogin", dynamicParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                // Handle the exception, log, or rethrow if needed
            }
            finally
            {
                DapperConnection.CloseConnection(this._conn);
            }

            return userDetail;
        }

        //**********************************************************************************************************************

        public List<sellerformdata> customerStatusRepo(string LoggedInName)
        {
            List<sellerformdata> obj = new List<sellerformdata>();
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", LoggedInName, DbType.String, ParameterDirection.Input);
            obj = conn.Query<sellerformdata>("Customerstatus", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
            DapperConnection.CloseConnection(this._conn);

            return obj;

        }
    }
}
