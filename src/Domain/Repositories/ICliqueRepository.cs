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
        void AddClique(Clique clique);
        Clique GetClique(long cliqueId);
    }
}