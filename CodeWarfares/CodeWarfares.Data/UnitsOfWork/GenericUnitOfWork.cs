using CodeWarfares.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.UnitsOfWork
{
    public class GenericUnitOfWork : IUnitOfWork
    {
        private readonly ICodeWarfaresDbContext dbContext;

        public GenericUnitOfWork(ICodeWarfaresDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
        public void Dispose()
        {
        }
    }
}
