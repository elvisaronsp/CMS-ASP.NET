using CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DataServices.Contracts
{
    public interface IMenuLocationService
    {

        IQueryable<MenuLocation> All();

        Guid Add(MenuLocation menuLocation);

        MenuLocation GetById(Guid id);

        MenuLocation Update(MenuLocation menuLocation);

        bool Delete(Guid id);

        void Dispose();
    }
}
