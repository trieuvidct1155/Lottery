using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BANVESO.Models
{
    public class TicketDAO
    {
        LotteryEntities db = null;
        public TicketDAO()
        {
            db = new LotteryEntities();
        }
        public List<LOAIVESO> listLOAIVESO()
        {
            return db.LOAIVESOes.ToList();
        }
    }
}