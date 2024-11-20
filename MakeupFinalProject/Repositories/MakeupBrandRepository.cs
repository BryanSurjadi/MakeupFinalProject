using MakeupFinalProject.Factories;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Repositories
{
    public class MakeupBrandRepository
    {
        MakeupDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<MakeupBrand> getAllBrands()
        {
            return db.MakeupBrands.OrderByDescending(mb => mb.MakeupBrandRating).ToList();
        }

        public MakeupBrand getBrandFromID(int id)
        {
            return (from x in db.MakeupBrands where id == x.MakeupBrandID select x).FirstOrDefault();
        }

        public int getLastID()
        {
            return (from x in db.MakeupBrands select x.MakeupBrandID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            int id = getLastID();
            if (id == 0)
            {
                id = 1;
            }
            else
            {
                id = id + 1;
            }
            return id;
        }

        public void delete(int id)
        {
            var x = getBrandFromID (id);
            db.MakeupBrands.Remove(x);  
            db.SaveChanges();
        }

        public void insert(string name,int rating)
        {
            int id = generateID();
            MakeupBrand brand = MakeupBrandFactory.Create(id, name,rating);
            db.MakeupBrands.Add(brand);
            db.SaveChanges();
        }

        public void update(int id,string name,int rating)
        {
            var x = getBrandFromID (id);
            x.MakeupBrandName = name;
            x.MakeupBrandRating = rating;
            db.SaveChanges ();
        }




    }
}