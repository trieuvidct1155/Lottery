using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANVESO.Models
{
    public class AgencyDAO
    {
        LotteryEntities db = null;
        public AgencyDAO()
        {
            db = new LotteryEntities();
        }
        public List<DAILI> listDAILI()
        {
            return db.DAILIs.ToList();
        }
    }
}