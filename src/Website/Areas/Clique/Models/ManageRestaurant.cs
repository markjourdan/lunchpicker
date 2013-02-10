using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Web.Areas.Clique.Models
{
    public class ManageRestaurant
    {
        public IEnumerable<State> States { get; set; } 
    }
}