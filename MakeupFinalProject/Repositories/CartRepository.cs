using MakeupFinalProject.Factories;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Repositories
{
    public class CartRepository
    {
        MakeupDatabaseEntities db = new MakeupDatabaseEntities();

        public List<Cart> getCart(int id)
        {
            return db.Carts.Where(c => c.UserID == id).ToList();
        }

        protected int getLastID()
        {
            return (from x in db.Carts select x.CartID).ToList().LastOrDefault();
        }

        protected int generateID()
        {
            int id = getLastID();
            if (db == null)
            {
                id = 1;
            }
            else
            {
                id = id + 1;
            }
            return id;
        }

        public void addToCart(int userid,int makeupid,int qty)
        {
            int cartid = generateID();
            Cart cart = CartFactory.Create(cartid,userid,makeupid,qty);
            db.Carts.Add(cart);
            db.SaveChanges();

        }

        public void deleteCart(int userID)
        {
            var cartItems = getCart(userID);
            db.Carts.RemoveRange(cartItems);
            db.SaveChanges();
        }

        protected int getLastThId()
        {
            return (from x in db.TransactionHeaders select x.TransactionID).ToList().LastOrDefault();
        }

        protected int generateThId()
        {
            int id = getLastThId();
            if (db == null)
            {
                id = 1;
            }
            else
            {
                id = id + 1;
            }
            return id;
        }


        public void checkOut(int userid)
        {
            var cartItems = getCart(userid);

            if (cartItems == null || !cartItems.Any())
            {
                throw new InvalidOperationException("Cart is empty.");
            }

            int thId = generateThId();
            TransactionHeader th = TransactionHeaderFactory.Create(thId,userid,DateTime.Today,"unhandled");
            db.TransactionHeaders.Add(th);
            db.SaveChanges();

            foreach (var item in cartItems)
            {   
                //if ada Transaction Id dan MakeupID yang sama maka add quantity nya.
                var existingDetail = db.TransactionDetails.FirstOrDefault(td => td.TransactionID == th.TransactionID && td.MakeupID == item.MakeupID);

                if (existingDetail == null)
                {
                    TransactionDetail transactionDetail = TransactionDetailFactory.Create(th.TransactionID, item.MakeupID, item.Quantity);
                    db.TransactionDetails.Add(transactionDetail);
                    db.SaveChanges();
                }
                else
                {
                    // Update  quantity transaction detail
                    existingDetail.Quantity += item.Quantity;
                    db.Entry(existingDetail).State = EntityState.Modified;
                }



            }
           

            deleteCart(userid);
        }


    }
}