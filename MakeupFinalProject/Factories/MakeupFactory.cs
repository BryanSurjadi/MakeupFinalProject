using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Factories
{
    public class MakeupFactory
    {
        public static Makeup Create(int id,string name,int price,int weight,int typeid,int brandid) {
            Makeup makeups = new Makeup();
            makeups.MakeupID = id;
            makeups.MakeupName = name;
            makeups.MakeupPrice = price;
            makeups.MakeupWeight = weight;
            makeups.MakeupTypeID = typeid;
            makeups.MakeupBrandID = brandid;
            return makeups;
        
        }
    }
}