using CodeWarfares.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Services.Contracts.Account
{
    public interface IUserServices
    {
        /// <summary>
        /// Adds submition to user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="submition"></param>
        void AddSubmitionToUser(string userId, Submition submition);

        /// <summary>
        /// Adds problem to user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="problem"></param>
        void AddProblemToUser(string userId, Problem problem);

        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Gets all users and updates their total points
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAllUsersWithPoints();

        /// <summary>
        /// Gets users by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetByUsername(string username);
    }
}
