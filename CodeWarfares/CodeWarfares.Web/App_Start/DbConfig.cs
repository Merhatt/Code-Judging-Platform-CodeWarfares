using CodeWarfares.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CodeWarfares.Data.Migrations;

namespace CodeWarfares.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeWarfaresDbContext, Configuration>());
            CodeWarfaresDbContext.Create().Database.Initialize(true);
        }
    }
}