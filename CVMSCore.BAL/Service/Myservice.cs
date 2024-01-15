using CVMSCore.BAL.Models;
using CVMSCore.BAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVMSCore.BAL.Service
{
    public class Myservice
    {
        Myrepo _repo = new Myrepo();//create repository object
        public List<Mymodel> GetList()
        {
            List<Mymodel> list = new List<Mymodel>();
            list = _repo.GetData();

            return list;
        }
    }
}
