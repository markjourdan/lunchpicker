using System;
using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface ICliqueRepository
    {
        Clique GetClique(Guid friendlyKey);
        IEnumerable<Clique> GetCliques();
        void AddClique(Clique clique);
        Clique GetClique(long cliqueId);
    }
}