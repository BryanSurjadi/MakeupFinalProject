using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Handler
{
    public class MakeupHandler
    {
        MakeupRepository repo = new MakeupRepository();
        public List<Makeup> GetMakeups() { 
            return repo.GetMakeups();
        }

        public void deleteMakeup(int id)
        {
            repo.deleteMakeup(id);
        }

        public void InsertMakeup(string name, int price, int weight, int typeid, int brandid)
        {
            repo.InsertMakeup(name, price, weight, typeid, brandid);
        }

        public Makeup getMakeupFromID(int id)
        {
            return repo.getMakeupFromID(id);
        }

        public void updateMakeup(int id, string name, int price, int weight, int typeid, int brandid)
        {
            repo.updateMakeup(id, name, price, weight, typeid, brandid);
        }
    }
}