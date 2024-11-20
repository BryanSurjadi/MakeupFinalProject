using MakeupFinalProject.Factories;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Repositories
{
    public class MakeupRepository
    {
        MakeupDatabaseEntities db = DatabaseSingleton.getInstance();
        public List<Makeup> GetMakeups()
        {
            return db.Makeups.ToList();
        }

        public Makeup getMakeupFromID(int id)
        {
            return (from x in db.Makeups where id == x.MakeupID select x).FirstOrDefault();
        }
        public int lastId()
        {
            return (from x in db.Makeups select x.MakeupID).ToList().LastOrDefault();
        }

        public int generateID()
        {
            int id = lastId();
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

        public void updateMakeup(int id,string name,int price,int weight,int typeid,int brandid)
        {
            var x = getMakeupFromID(id);
            x.MakeupID = id;
            x.MakeupName = name;
            x.MakeupPrice = price;
            x.MakeupWeight = weight;
            x.MakeupTypeID = typeid;
            x.MakeupBrandID = brandid;
            db.SaveChanges();
        }

        public void deleteMakeup(int id)
        {
            var x = getMakeupFromID(id);
            db.Makeups.Remove(x);
            db.SaveChanges ();
        }

        public void InsertMakeup(string name, int price, int weight, int typeid, int brandid)
        {
            int id = generateID();
            Makeup makeup = MakeupFactory.Create(id, name, price, weight, typeid, brandid);
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }

    }
}