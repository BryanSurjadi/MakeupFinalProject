using MakeupFinalProject.Handler;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Controller
{
    
    public class CartController
    {
        CartHandler handler = new CartHandler();

        public List<Cart> getCart(int id)
        {
            return handler.GetCart(id);
        }

        public string checkQty(int qty)
        {
            if (qty < 0)
            {
                return "Please Fill the right qty";
            }
            return null;
        }
        public string addToCart(int userid, int makeupid, int qty)
        {
            string error = null;
            if(error==null)
            {
                error = checkQty(qty);
            }
            if(error == null)
            {
                handler.addToCart(userid, makeupid, qty);
                error = null;
            }

            return error;
        }

        public void deleteCart (int id)
        {
            handler.deleteCart(id);
        }


        public void checkout(int id)
        {
            handler.checkout(id);
        }
    }
}