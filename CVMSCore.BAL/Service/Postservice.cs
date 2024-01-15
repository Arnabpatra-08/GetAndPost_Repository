using CVMSCore.BAL.Models;
using CVMSCore.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVMSCore.BAL.Service
{
    public class Postservice
    {

        Postrepo _repo = new Postrepo();
        //public int addempser(Postmodel obj)
        //{
        //    return _repo.SaveEmp(obj);
        //}

        public int AddEmpSer(Mymodel empModel)
        {
            int num = 102;
            try
            {
                return _repo.SaveEmp(empModel);


            }
            catch
            {

            }
            return num;
        }
    }
}
