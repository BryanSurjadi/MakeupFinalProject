using MakeupFinalProject.Handler;
using MakeupFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Controller
{
    public class TypeController
    {
        TypeHandler handler = new TypeHandler();


        public List<MakeupType> getAllTypes()
        {
            return handler.getAllTypes();
        }

        public void delete(int id)
        {
            handler.delete(id);
        }

        public MakeupType getTypeFromID(int id)
        {
            return handler.getTypeFromID(id);
        }

        public string checkName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length < 1 || name.Length > 99)
            {
                return "Name must be filled (1-99 characters)";
            }
            return null;
        }
        public string updateType(int id, string name)
        {
            string error = null;
            if(error == null)
            {
                error = checkName(name);
            }
            if(error == null)
            {
                handler.updateType(id, name);   
            }
            return error;
        }

        public string insert(string name)
        {
            string error = null;
            if (error == null)
            {
                error = checkName(name);
            }
            if (error == null)
            {
                handler.insert(name);
            }
            return error;
        }
    }
}