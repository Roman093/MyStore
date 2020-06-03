using NLayerApp.DAL.EF;
using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private MobileContext db;
        public CategoryRepository(MobileContext context)
        {
            this.db = context;
        }
        public void Create(Category category)
        {
            db.Categorys.Add(category);
        }

        public void Delete(int id)
        {
            Category category = db.Categorys.Find(id);
            if (category != null)
                db.Categorys.Remove(category);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return db.Categorys.Include(o => o.Product).Where(predicate).ToList();
        }

        public Category Get(int id)
        {
            return db.Categorys.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categorys.Include(o => o.Product); ;
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }
    }
}
