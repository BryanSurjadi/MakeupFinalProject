using MakeupFinalProject.Factories;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Repositories
{
    public class MakeupTypeRepository
    {
        MakeupDatabaseEntities db = DatabaseSingleton.getInstance();

        public List<MakeupType> getAllTypes()
        {
            return db.MakeupTypes.ToList();
        }

        public MakeupType getTypeFromID(int id)
        {
            return (from x in db.MakeupTypes where id == x.MakeupTypeID select x).FirstOrDefault();
        }
        public void delete(int id)
        {
            var x = getTypeFromID(id);
            db.MakeupTypes.Remove(x);
            db.SaveChanges();
        }

        public void updateType(int id,string name)
        {
            var x = getTypeFromID(id);
            x.MakeupTypeName = name;
            db.SaveChanges();
        }

        public void insert(string name)
        {
            int id = generateID();
            MakeupType type = MakeupTypeFactory.Create(id, name);
            db.MakeupTypes.Add(type);
            db.SaveChanges();
        }

        public int getLastID()
        {
            return (from x in db.MakeupTypes select x.MakeupTypeID).ToList().LastOrDefault();
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


    }
}