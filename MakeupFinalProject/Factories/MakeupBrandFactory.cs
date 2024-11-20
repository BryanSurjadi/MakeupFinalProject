using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Factories
{
    public class MakeupBrandFactory
    {

        public static MakeupBrand Create(int id,string name,int rating) {
            MakeupBrand makeupBrand = new MakeupBrand();
            makeupBrand.MakeupBrandID = id;
            makeupBrand.MakeupBrandName = name; 
            makeupBrand.MakeupBrandRating = rating;
            return makeupBrand;

        }

    }
}