﻿using System.Collections.Generic;
using Dino;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Infrastructure.Data;

namespace LunchPicker.Infrastructure.Repositories
{
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
        public AccountRepository(IObjectContextProvider contextProvider) : base(contextProvider) { }

        public IEnumerable<User> GetCliquesUsers(int cliqueId)
        {
            return FindSingleOrDefault<Clique>(c => c.CliqueId == cliqueId).Users;
        }

        public IEnumerable<Restaurant> GetCliquesRestaurants(int cliqueId)
        {
            return FindSingleOrDefault<Clique>(c => c.CliqueId == cliqueId).Restaurants;
        }

        public IEnumerable<User> GetUsers()
        {
            return ContextProvider.GetContext<LunchContext>().Query<User>();
        }

        public void AddUser(User user)
        {
            ContextProvider.GetContext<LunchContext>().Add(user);
        }

        public User GetUserByUserName(string username)
        {
            return FindSingleOrDefault<User>(u => u.UserName == username);
        }

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            return Find<User>(u => u.EmailAddress == email);
        }

        public IEnumerable<Clique> GetCliques()
        {
            return ContextProvider.GetContext<LunchContext>().Query<Clique>();
        }

        public void AddClique(Clique clique)
        {
            ContextProvider.GetContext<LunchContext>().Add(clique);
        }

        public Clique GetClique(int cliqueId)
        {
            return FindSingleOrDefault<Clique>(c => c.CliqueId == cliqueId);
        }
    }
}
