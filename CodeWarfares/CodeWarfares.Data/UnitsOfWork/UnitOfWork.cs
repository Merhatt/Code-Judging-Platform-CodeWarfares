using CodeWarfares.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ICodeWarfaresDbContext context;

        public UnitOfWork(ICodeWarfaresDbContext context)
        {
            if (context == null)
            {
                throw new NullReferenceException("Context cannot be null");
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
