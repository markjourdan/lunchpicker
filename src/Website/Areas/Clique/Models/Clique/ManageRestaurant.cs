using System.Collections.Generic;
using LunchPicker.Domain.DataTransferObject;

namespace LunchPicker.Web.Areas.Clique.Models.Clique
{
    public class ManageRestaurant
    {
        public IEnumerable<StateDto> States { get; set; }
        public CliqueDto Clique { get; set; }
    }
}