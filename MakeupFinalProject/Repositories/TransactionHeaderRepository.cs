using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Repositories
{
    public class TransactionHeaderRepository
    {
        static MakeupDatabaseEntities db = DatabaseSingleton.getInstance();
        public List<TransactionHeader> getAll()
        {
            return db.TransactionHeaders.ToList();
        }

        public List<TransactionHeader> getFromID(int userid)
        {
            return (from x in db.TransactionHeaders where x.UserID == userid select x).ToList();
        }

        public TransactionHeader getFromTransactionID(int transactionid)
        {
            return(from x in db.TransactionHeaders where x.TransactionID == transactionid select x).FirstOrDefault();   
        }

        public void update(int id)
        {
            TransactionHeader x = getFromTransactionID(id);
            x.Status = "handled";
            db.SaveChanges();

        }
    }
}