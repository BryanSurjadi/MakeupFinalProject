using MakeupFinalProject.Models;
using MakeupFinalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeupFinalProject.Handler
{
    public class BrandHandler
    {
        MakeupBrandRepository repo = new MakeupBrandRepository();

        public void insert(string name, int rating)
        {
            repo.insert(name, rating);
        }

        public MakeupBrand getBrandFromID(int id)
        {
            return repo.getBrandFromID(id);
        }

        public void update(int id, string name, int rating)
        {
            repo.update(id, name, rating);
        }

        public void delete(int id)
        {
            repo.delete(id);
        }

        public List<MakeupBrand> getAllBrands()
        {
            return repo.getAllBrands();
        }
    }
}