using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Handler
{
    public class TransactionDetailHandler
    {
        TransactionDetailRepository repo = new TransactionDetailRepository();

        public List<TransactionDetail> getByTransactionId(int transactionId)
        {
            return repo.getByTransactionId(transactionId);
        }

    }
}