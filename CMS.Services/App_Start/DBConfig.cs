namespace CMS.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data.Entity;
    using Data;
    public static class DBConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Data.DbContext, Data.Migrations.Configuration>());
            Data.DbContext.Create().Database.Initialize(true);
        }
    }
}
 