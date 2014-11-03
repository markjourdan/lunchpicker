using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetCliquesUsers(int cliqueId);
        IEnumerable<User> GetUsers(long cliqueId);
        void AddUser(User user);
        User GetUserByUserName(string username);
        IEnumerable<User> GetUsersByEmail(string email);
        void AddUser(User user, Clique clique);
        User GetUser(long userId);
        void DeleteUser(User userToDelete);
        IEnumerable<User> GetUsers();
    }
}
