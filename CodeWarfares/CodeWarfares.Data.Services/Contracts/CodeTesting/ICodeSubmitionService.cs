using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarfares.Data.Services.Contracts.CodeTesting
{
    /// <summary>
    /// Service for submiting code
    /// </summary>
    public interface ICodeSubmitionService
    {
        /// <summary>
        /// Send code submition
        /// </summary>
        /// <param name="user"></param>
        /// <param name="problem"></param>
        /// <param name="source"></param>
        /// <param name="laungage"></param>
        void SendSubmition(User user, Problem problem, string source, ContestLaungagesTypes laungage);

        /// <summary>
        /// Gets all user submitions
        /// </summary>
        /// <param name="user"></param>
        /// <param name="problem"></param>
        /// <returns></returns>
        IQueryable<Submition> GetAllUserSubmition(User user, Problem problem);
    }
}