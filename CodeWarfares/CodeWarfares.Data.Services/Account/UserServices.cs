using CodeWarfares.Data.Contracts;
using CodeWarfares.Data.Models;
using CodeWarfares.Data.Services.Contracts.Account;
using CodeWarfares.Data.Services.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeWarfares.Data.Services.Account
{
    public class UserServices : IUserServices
    {
        private IRepository<User> usersRepository;

        public UserServices(IRepository<User> users)
        {
            if (users == null)
            {
                throw new NullReferenceException("Users cannot be null");
            }

            this.usersRepository = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.usersRepository.All();
        }

        public void AssignRole(User user, IdentityUserRole role)
        {
            if (user == null)
            {
                throw new NullReferenceException("user cannot be null");
            }

            if (role == null)
            {
                throw new NullReferenceException("role cannot be null");
            }

            user.Roles.Add(role);
            this.usersRepository.SaveChanges();
        }

        public void AddSubmitionToUser(string userId, Submition submition)
        {
            if (userId == null)
            {
                throw new NullReferenceException("userId cannot be null");
            }

            if (submition == null)
            {
                throw new NullReferenceException("submition cannot be null");
            }

            this.usersRepository.GetById(userId).Submition.Add(submition);
            this.usersRepository.SaveChanges();
        }

        public void AddProblemToUser(string userId, Problem problem)
        {
            if (userId == null)
            {
                throw new NullReferenceException("userId cannot be null");
            }

            if (problem == null)
            {
                throw new NullReferenceException("problem cannot be null");
            }

            var user = this.usersRepository.GetById(userId);
            bool shouldAddProblem = user.Problems.FirstOrDefault(p => p.Id == problem.Id) == null;

            if (shouldAddProblem)
            {
                user.Problems.Add(problem);
            }

            this.usersRepository.SaveChanges();
        }

        public User GetByUsername(string username)
        {
            return this.usersRepository.All().FirstOrDefault(x => x.UserName == username);
        }

        public IEnumerable<User> GetAllUsersWithPoints()
        {
            var allUsers = this.GetAll().ToList();

            foreach (var user in allUsers)
            {
                var problems = user.Problems;

                user.TotalPoints = 0;

                foreach (var problem in problems)
                {
                    double biggestCompletePercentage = problem.Submitions.Where(s => s.AuthorId == user.Id)
                        .OrderByDescending(x => x.CompletedPercentage).FirstOrDefault().CompletedPercentage;

                    user.TotalPoints += (long)((biggestCompletePercentage / 100) * problem.Xp);
                }
            }

            this.usersRepository.SaveChanges();

            return allUsers;
        }
    }
}
