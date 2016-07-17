namespace CMS.DataServices.Contracts
{
    using Models;
    using System;
    using System.Linq;
    public interface IMenuService
    {
        IQueryable<Menu> All();

        Guid Add(Menu menu);

        Menu GetById(Guid id);

        Menu Update(Menu menu);

        bool Delete(Guid id);

        void Dispose();
    }
}
