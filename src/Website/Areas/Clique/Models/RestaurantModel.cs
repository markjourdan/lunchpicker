using LunchPicker.Domain.Entities;

namespace LunchPicker.Web.Areas.Clique.Models
{
    public class RestaurantModel
    {
        public long RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? StateId { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public State State { get; set; }
    }
}