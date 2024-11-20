using MakeupFinalProject.Handler;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Controller
{
    public class BrandController
    {
        BrandHandler handler = new BrandHandler();

        public string checkName (string name)
        {
            if(string.IsNullOrEmpty(name) || name.Length < 1 || name.Length > 99)
            {
                return "Name must be filled (1-99 characters)";
            }
            return null;
        }

        public string checkRating (int rating)
        {
            if(rating < 1 || rating > 100)
            {
                return "Rating must be in between 0-100";
            }
            return null;
        }
        public string insert(string name, int rating)
        {
            string error = null;
            if(error == null)
            {
                error = checkName(name);
            }
            if(error == null)
            {
                error = checkRating(rating);
            }
            if(error == null)
            {
                handler.insert(name, rating);
                error = null;
            }
            return error;
        }

        public MakeupBrand getBrandFromID(int id)
        {
            return handler.getBrandFromID(id);
        }

        public string update(int id, string name, int rating)
        {
            string error = null;
            if (error == null)
            {
                error = checkName(name);
            }
            if (error == null)
            {
                error = checkRating(rating);
            }
            if (error == null)
            {
                handler.update(id,name, rating);
                error = null;
            }
            return error;
        }

        public void delete(int id)
        {
            handler.delete(id);
        }

        public List<MakeupBrand> getAllBrands()
        {
            return handler.getAllBrands();
        }
    }
}