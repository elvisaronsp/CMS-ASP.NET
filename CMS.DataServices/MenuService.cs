namespace CMS.DataServices
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Data;
    using System.Data.Entity.Infrastructure;
    public class MenuService : IMenuService
    {
        private readonly IRepository<Menu> db;

        public MenuService()
        {
            this.db = new EfGenericRepository<Menu>(new CMSDbContext());
        }

        public Guid Add(Menu menu)
        {
            
            db.Add(menu);
            db.SaveChanges();
           
            return menu.Id;
        }

        public Menu GetById(Guid id)
        {
            Menu menu = db.GetById(id);
            if (menu == null)
            {
                return null;
            }

            return menu;
        }

        public IQueryable<Menu> All()
        {
            return db.All();
        }

        public bool Delete(Guid id)
        {
            Menu menu = db.GetById(id);
            if (menu == null)
            {
                return false;
            }

            db.Delete(menu);
            db.SaveChanges();

            return true;
        }

        public Menu Update(Menu menu)
        {
            db.Update(menu);
            db.SaveChanges();
            return menu;
        }

        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
