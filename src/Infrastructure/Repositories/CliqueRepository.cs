using System;
using System.Collections.Generic;
using Dino;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Infrastructure.Data;

namespace LunchPicker.Infrastructure.Repositories
{
    public class CliqueRepository : RepositoryBase, ICliqueRepository
    {
        public CliqueRepository(IObjectContextProvider contextProvider) : base(contextProvider)
        {
        }
        public Clique GetClique(Guid friendlyKey)
        {
            return FindSingleOrDefault<Clique>(c => c.FriendlyKey == friendlyKey);
        }
        public IEnumerable<Clique> GetCliques()
        {
            return ContextProvider.GetContext<LunchContext>().Query<Clique>();
        }

        public IEnumerable<Clique> GetCliquesByUser(string userName)
        {
            return FindSingleOrDefault<User>(c => c.UserName == userName).Cliques;
        }

        public void AddClique(Clique clique)
        {
            ContextProvider.GetContext<LunchContext>().Add(clique);
        }
        public Clique GetClique(long cliqueId)
        {
            return FindSingleOrDefault<Clique>(c => c.CliqueId == cliqueId);
        }
    }
}