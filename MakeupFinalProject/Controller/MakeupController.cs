using MakeupFinalProject.Handler;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Controller
{
    public class MakeupController
    {
        MakeupHandler handler = new MakeupHandler();

        public List<Makeup> GetMakeups()
        {
            return handler.GetMakeups();
        }

        public void deleteMakeup(int id)
        {
            handler.deleteMakeup(id);
        }

        public string checkMakeupName(string name)
        {
            if(name == null)
            {
                return "Fill the names";
            }
            if(name.Length < 1 || name.Length > 99) 
            {
                return "Name must be in between (1-99 Characters)";
            }
            return null;
        }

        public string checkPrice (int price)
        {
            if (price < 1)
            {
                return "Price must be higher than 1";
            }
            return null;
        }

        public string checkWeight(int weight)
        {
            if (weight > 1500)
            {
                return "Weight must be less than 1500 (grams)";
            }
            if (weight < 0)
            {
                return "Enter weight";
            }
            return null;
        }

        public string checkTypeID(int id)
        {
            if (id < 0)
            {
                return "Enter the right MakeupType ID";
            }
            return null;
        }

        public string checkBrandID(int id)
        {
            if (id < 0)
            {
                return "Enter the correct Brand Id";
            }
            return null;
        }

        public string insert(string name, int price, int weight, int typeid, int brandid)
        {
            string error = null;
            if(error == null)
            {
                error = checkMakeupName(name);
            }
            if(error == null)
            {
                error = checkPrice(price);
            }
            if(error == null)
            {
                error = checkWeight(weight);
            }
            if(error == null)
            {
                error = checkTypeID(typeid);
            }
            if (error == null)
            {
                error = checkBrandID(brandid);  
            }
            if(error == null)
            {
                handler.InsertMakeup(name,price,weight,typeid,brandid);
            }
            return error;
        }

        public Makeup getMakeupFromID(int id)
        {
            return handler.getMakeupFromID(id);
        }
        public string updateMakeup(int id, string name, int price, int weight, int typeid, int brandid)
        {
            string error = null;
            if (error == null)
            {
                error = checkMakeupName(name);
            }
            if (error == null)
            {
                error = checkPrice(price);
            }
            if (error == null)
            {
                error = checkWeight(weight);
            }
            if (error == null)
            {
                error = checkTypeID(typeid);
            }
            if (error == null)
            {
                error = checkBrandID(brandid);
            }
            if (error == null)
            {
                handler.updateMakeup(id,name, price, weight, typeid, brandid);
            }
            return error;
        }
    }
}