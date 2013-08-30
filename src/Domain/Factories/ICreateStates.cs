using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Domain.Factories
{
    public interface ICreateStates
    {
        IList<State> USA(IList<State> existingStates);
    }
}
