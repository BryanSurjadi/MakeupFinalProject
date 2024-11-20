using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Handler
{
    public class TransactionHeaderHandler
    {
        TransactionHeaderRepository repo = new TransactionHeaderRepository();
        public List<TransactionHeader> getAll()
        {
            return repo.getAll();
        }

        public List<TransactionHeader> getFromID(int userid)
        {
            return repo.getFromID(userid);
        }

        public void update(int id)
        {
            repo.update(id);    
        }

        public TransactionHeader getFromTransactionID(int transactionid)
        {
            return repo.getFromTransactionID(transactionid);
        }
    }
}