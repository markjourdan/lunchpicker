using System.Collections.Generic;
using System.Data;
using Dino;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Infrastructure.Data;

namespace LunchPicker.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(IObjectContextProvider contextProvider) : base(contextProvider) { }

        public IEnumerable<User> GetCliquesUsers(int cliqueId)
        {
            return FindSingleOrDefault<Clique>(c => c.CliqueId == cliqueId).Users;
        }
       
        public IEnumerable<User> GetUsers(long cliqueId)
        {
            var clique = FindSingleOrDefault<Clique>(c => c.CliqueId == cliqueId);
            if (clique != null)
                return clique.Users;

            throw new ObjectNotFoundException(string.Format("Unable to locate a Clique with Id: {0}", cliqueId));
        }

        public IEnumerable<User> GetUsers()
        {
            return ContextProvider.GetContext<LunchContext>().Query<User>();
        }

        public void AddUser(User user)
        {
            ContextProvider.GetContext<LunchContext>().Add(user);
        }

        public void AddUser(User user, Clique clique)
        {
            ContextProvider.GetContext<LunchContext>().Add(user);
            clique.Users.Add(user);
        }

        public User GetUserByUserName(string username)
        {
            return FindSingleOrDefault<User>(u => u.UserName == username);
        }

        public IEnumerable<User> GetUsersByEmail(string email)
        {
            return Find<User>(u => u.EmailAddress == email);
        }

        public User GetUser(long userId)
        {
            return FindSingleOrDefault<User>(u => u.UserId == userId);
        }

        public void DeleteUser(User userToDelete)
        {
            Delete(userToDelete);
        }
    }
}
