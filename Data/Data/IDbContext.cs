using CMS.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data
{
    public interface IDbContext
    {

        IDbSet<MenuLocation> MenuLocations { get; set; }

        IDbSet<Menu> Menus { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();

    }
}