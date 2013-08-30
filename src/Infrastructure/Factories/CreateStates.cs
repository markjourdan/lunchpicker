using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using LunchPicker.Domain.Entities;
using LunchPicker.Domain.Factories;

namespace LunchPicker.Infrastructure.Factories
{
    public class CreateStates : ICreateStates
    {
        private readonly IPrincipal _principal;

        public CreateStates(IPrincipal principal)
        {
            _principal = principal;
        }

        public IList<State> USA(IList<State> existingStates)
        {
            var newStates = new List<State>();

            foreach (var usaState in USAStates)
            {
                if (existingStates.All(a => a.Abreviation != usaState.Key))
                {
                    newStates.Add(new State(_principal) { Abreviation = usaState.Key, FullName = usaState.Value});
                }
            }

            return newStates;
        }

        private Dictionary<string, string> _USAStates; 
        private Dictionary<string, string> USAStates
        {
            get
            {
                return _USAStates ?? (_USAStates = new Dictionary<string, string>
                                                       {
                                                           {"AL", "Alabama"},
                                                           {"AK", "Alaska"},
                                                           {"AZ", "Arizona"},
                                                           {"AR", "Arkansas"},
                                                           {"CA", "California"},
                                                           {"CO", "Colorado"},
                                                           {"CT", "Connecticut"},
                                                           {"DE", "Delaware"},
                                                           {"FL", "Florida"},
                                                           {"GA", "Georgia"},
                                                           {"HI", "Hawaii"},
                                                           {"ID", "Idaho"},
                                                           {"IL", "Illinois"},
                                                           {"IN", "Indiana"},
                                                           {"IA", "Iowa"},
                                                           {"KS", "Kansas"},
                                                           {"KY", "Kentucky"},
                                                           {"LA", "Louisiana"},
                                                           {"ME", "Maine"},
                                                           {"MD", "Maryland"},
                                                           {"MA", "Massachusetts"},
                                                           {"MI", "Michigan"},
                                                           {"MN", "Minnesota"},
                                                           {"MS", "Mississippi"},
                                                           {"MO", "Missouri"},
                                                           {"MT", "Montana"},
                                                           {"NE", "Nebraska"},
                                                           {"NV", "Nevada"},
                                                           {"NH", "New Hampshire"},
                                                           {"NJ", "New Jersey"},
                                                           {"NM", "New Mexico"},
                                                           {"NY", "New York"},
                                                           {"NC", "North Carolina"},
                                                           {"ND", "North Dakota"},
                                                           {"OH", "Ohio"},
                                                           {"OK", "Oklahoma"},
                                                           {"OR", "Oregon"},
                                                           {"PA", "Pennsylvania"},
                                                           {"RI", "Rhode Island"},
                                                           {"SC", "South Carolina"},
                                                           {"SD", "South Dakota"},
                                                           {"TN", "Tennessee"},
                                                           {"TX", "Texas"},
                                                           {"UT", "Utah"},
                                                           {"VT", "Vermont"},
                                                           {"VA", "Virginia"},
                                                           {"WA", "Washington"},
                                                           {"WV", "West Virginia"},
                                                           {"WI", "Wisconsin"},
                                                           {"WY", "Wyoming"}
                                                       });
            }
        }
    }
}
