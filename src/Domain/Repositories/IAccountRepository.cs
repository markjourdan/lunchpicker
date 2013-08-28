using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<User> GetCliquesUsers(int cliqueId);
        IEnumerable<Restaurant> GetCliquesRestaurants(int cliqueId);
        IEnumerable<User> GetUsers();
        void AddUser(User user);
        User GetUserByUserName(string username);
        IEnumerable<User> GetUsersByEmail(string email);
        IEnumerable<Clique> GetCliques();
        void AddClique(Clique clique);
        void AddUser(User user, Clique clique);
        Clique GetClique(long cliqueId);
        User GetUser(long userId);
        void DeleteUser(User userToDelete);
    }
}
