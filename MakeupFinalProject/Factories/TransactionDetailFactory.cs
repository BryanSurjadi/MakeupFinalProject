using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int id,int makeupid,int qty)
        {

            TransactionDetail transactionDetail = new TransactionDetail();
            transactionDetail.TransactionID = id;
            transactionDetail.MakeupID = makeupid;
            transactionDetail.Quantity = qty;
            return transactionDetail;

        }
    }
}