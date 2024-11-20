using MakeupFinalProject.Handler;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Controller
{
    public class TransactionHeaderController
    {
        TransactionHeaderHandler handler = new TransactionHeaderHandler();

        public List<TransactionHeader> getAll()
        {
            return handler.getAll();
        }

        public List<TransactionHeader> getFromID(int userid)
        {
            return handler.getFromID(userid);
        }

        public void update(int id)
        {
            handler.update(id);
        }

        public TransactionHeader getFromTransactionID(int transactionid)
        {
            return handler.getFromTransactionID(transactionid);
        }
    }
}