using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Factories
{
    public class TransactionHeaderFactory
    {

        public static TransactionHeader Create(int id,int userid,DateTime date,string status) {
        
            TransactionHeader th = new TransactionHeader(); 
            th.TransactionID = id;
            th.UserID = userid;
            th.TransactionDate = date;
            th.Status = status;
            return th;
        
        }


    }
}