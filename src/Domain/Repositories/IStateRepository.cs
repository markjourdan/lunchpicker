using System.Collections.Generic;
using System.Linq;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Repositories
{
    public interface IStateRepository
    {
        void Add(State state);
        IQueryable<State> GetStates();
        State GetState(int stateId);
        void DeleteState(State state);
        void Add(IEnumerable<State> states);
    }
}
