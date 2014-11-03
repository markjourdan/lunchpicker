using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Dino;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Repositories;
using LunchPicker.Infrastructure.Data;

namespace LunchPicker.Infrastructure.Repositories
{
    public class StateRepository : RepositoryBase, IStateRepository
    {
        public StateRepository(IObjectContextProvider contextProvider) : base(contextProvider)
        {
        }

        public void Add(State state)
        {
            ContextProvider.GetContext<LunchContext>().Add(state);
        }

        public IQueryable<State> GetStates()
        {
            return FindAll<State>();
        }

        public State GetState(int stateId)
        {
            return FindSingleOrDefault<State>(c => c.StateId == stateId);
        }

        public void DeleteState(State state)
        {
            ContextProvider.GetContext<LunchContext>().Delete(state);
        }

        public void Add(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                Add(state);
            }
        }
    }
}
