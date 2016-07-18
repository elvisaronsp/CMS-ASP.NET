namespace CMS.DataServices
{
    using Contracts;
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MenuLocationService : IMenuLocationService
    {
        private readonly IRepository<MenuLocation> db;

        public MenuLocationService(IRepository<MenuLocation> db)
        {
            this.db = db;
        }

        public Guid Add(MenuLocation menuLocation)
        {
            db.Add(menuLocation);
            db.SaveChanges();

            return menuLocation.Id;
        }

        public IQueryable<MenuLocation> All()
        {
            return db.All();
        }

        public bool Delete(Guid id)
        {
            MenuLocation menuLocation = db.GetById(id);
            if (menuLocation == null)
            {
                return false;
            }

            db.Delete(menuLocation);
            db.SaveChanges();

            return true;
        }


        public MenuLocation GetById(Guid id)
        {
            MenuLocation menuLocation = db.GetById(id);
            return menuLocation;
        }

        public MenuLocation Update(MenuLocation menuLocation)
        {
            db.Update(menuLocation);
            db.SaveChanges();

            return menuLocation;
        }


        public void Dispose()
        {
            this.db.Dispose();
        }
    }
}
