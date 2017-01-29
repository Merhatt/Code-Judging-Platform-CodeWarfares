using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeWarfares.Data
{
    public class CodeWarfaresDbContext : IdentityDbContext<User>, ICodeWarfaresDbContext
    {
        public CodeWarfaresDbContext()
            : base("CodeWarfaresDB", throwIfV1Schema: false)
        {
        }

        public IDbSet<Problem> Problems { get; set; }

        public IDbSet<Submition> Submitions { get; set; }

        public IDbSet<Test> Tests { get; set; }

        public IDbSet<TestCompleted> TestsCompleted { get; set; }

        //TODO No statics
        public static CodeWarfaresDbContext Create()
        {
            return new CodeWarfaresDbContext();
        }
    }
}
