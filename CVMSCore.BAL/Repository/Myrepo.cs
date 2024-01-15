using CVMSCore.BAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CVMSCore.BAL.Repository
{
    public class Myrepo
    {

        private SqlConnection _conn;  //for sql connection
        private DapperConnection dapper = new DapperConnection(ConnectionFile.Connection_ANTSDB); //dapper connection with connection string name 

        public List<Mymodel> GetData()   //list creating using the controller method GetData
        {
            List<Mymodel> obj = new List<Mymodel>();   //model name object creating using list

            this._conn = this.dapper.GetConnection();      //connection with database table to get the data from database

            DapperConnection.OpenConnection(this._conn);//if connection is right then it will be open
            SqlConnection conn = this._conn;
            obj = conn.Query<Mymodel>("GetMytable", commandType:CommandType.StoredProcedure).ToList();  // connection with procedure in database 
            DapperConnection.CloseConnection(this._conn);// close

            return obj;
        }

        
    }
}
