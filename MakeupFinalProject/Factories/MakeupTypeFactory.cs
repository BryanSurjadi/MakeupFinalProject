using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Factories
{
    public class MakeupTypeFactory
    {
        public static MakeupType Create(int id,string name) { 
            MakeupType types = new MakeupType();
            types.MakeupTypeID = id;
            types.MakeupTypeName = name;
            return types;

        }

    }
}