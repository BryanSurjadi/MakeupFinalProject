using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Repositories
{
    public class TransactionDetailRepository
    {
        static MakeupDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<TransactionDetail> getByTransactionId(int transactionId)
        {
            return db.TransactionDetails.Where(td => td.TransactionID == transactionId).ToList();
        }

    }
}