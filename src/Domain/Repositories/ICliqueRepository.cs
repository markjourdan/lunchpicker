using System;
using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface ICliqueRepository
    {
        Clique GetClique(Guid friendlyKey);
        IEnumerable<Clique> GetCliques();
        IEnumerable<Clique> GetCliquesByUser(string userName); 
        void Add(Clique clique);
        Clique GetClique(long cliqueId);
        void Delete(Clique clique);
    }
}