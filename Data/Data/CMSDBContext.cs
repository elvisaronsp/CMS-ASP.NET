﻿using CMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CMSDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public CMSDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<MenuLocation> MenuLocations { get; set; }

        public virtual IDbSet<Menu> Menus { get; set; }

        public static CMSDbContext Create()
        {
            return new CMSDbContext();
        }

        public System.Data.Entity.DbSet<CMS.Models.ApplicationUser> ApplicationUsers { get; set; }
    } 
}