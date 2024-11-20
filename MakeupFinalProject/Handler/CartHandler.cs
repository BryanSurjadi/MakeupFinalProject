using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Handler
{
    public class CartHandler
    {
        CartRepository repo = new CartRepository();

        public List<Cart> GetCart(int id )
        {
            return repo.getCart(id);
        }

        public void addToCart(int userid, int makeupid, int qty )
        {
            repo.addToCart(userid, makeupid, qty);
        }

        public void deleteCart (int id)
        {
            repo.deleteCart(id);
        }

        public void checkout (int id)
        {
            repo.checkOut(id);
        }
    }
}