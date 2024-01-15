using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVMSCore.BAL.Models;

namespace CVMSCore.BAL.Repository
{
    public class Postrepo
    {
        private SqlConnection _conn;
        private DapperConnection dapper = new DapperConnection(ConnectionFile.Connection_ANTSDB);

        public int SaveEmp(Mymodel emp)
        {
            DynamicParameters dynamicParameters1 = new DynamicParameters();
            //  dynamicParameters1.Add("EmpIdd", (object)0, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("Name", (object)emp.Name, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("Lastname", (object)emp.Lastname, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters1.Add("Address", (object)emp.Address, new DbType?(), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            this._conn = this.dapper.GetConnection();
            DapperConnection.OpenConnection(this._conn);
            SqlConnection conn = this._conn;
            DynamicParameters dynamicParameters2 = dynamicParameters1;
            CommandType? nullable1 = new CommandType?(CommandType.StoredProcedure);
            int? nullable2 = new int?();
            CommandType? nullable3 = nullable1;
            string? str = SqlMapper.ExecuteScalar((IDbConnection)conn, "Getnewdata", (object)dynamicParameters2, (IDbTransaction)null, nullable2, nullable3).ToString();
            DapperConnection.CloseConnection(this._conn);
            int num = Convert.ToInt32(str);

            return num;
        }
    }
}
