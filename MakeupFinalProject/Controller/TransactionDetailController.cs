using MakeupFinalProject.Handler;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Controller
{
    public class TransactionDetailController
    {

        TransactionDetailHandler handler = new TransactionDetailHandler ();
        public List<TransactionDetail> getByTransactionId(int transactionId)
        {
            return handler.getByTransactionId(transactionId);   
        }

    }
}