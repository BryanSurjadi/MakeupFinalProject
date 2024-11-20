using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Handler
{
    public class TypeHandler
    {
        MakeupTypeRepository repo = new MakeupTypeRepository();

        public List<MakeupType> getAllTypes()
        {
            return repo.getAllTypes();
        }

        public void delete(int id)
        {
            repo.delete(id);
        }
        public MakeupType getTypeFromID(int id)
        {
            return repo.getTypeFromID(id);
        }

        public void updateType(int id, string name)
        {
            repo.updateType(id, name);
        }

        public void insert(string name)
        {
            repo.insert(name);
        }

    }
}