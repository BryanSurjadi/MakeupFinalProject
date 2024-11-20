using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Factories
{
    public class CartFactory
    {
        public static Cart Create(int id,int userid,int makeupid,int qty) { 
            Cart carts = new Cart();
            carts.CartID = id;
            carts.UserID = userid;
            carts.MakeupID = makeupid;
            carts.Quantity = qty;
            return carts;
        
        }

    }
}