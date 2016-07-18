namespace CMS.API
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
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Data.CMSDbContext, Data.Migrations.Configuration>());
            Data.CMSDbContext.Create().Database.Initialize(true);
        }
    }
}
 