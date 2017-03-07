using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Contracts
{
    /// <summary>
    /// Unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        void Commit();
    }
}
