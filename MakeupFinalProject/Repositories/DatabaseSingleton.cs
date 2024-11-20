using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Repositories
{
    public class DatabaseSingleton
    {
        public static MakeupDatabaseEntities db = null;

        public static MakeupDatabaseEntities getInstance()
        {
            if(db == null)
            {
                db = new MakeupDatabaseEntities();
            }    
            return db;
        }

    }
}