namespace LunchPicker.Domain.DataTransferObject
{
    public class RestaurantListingDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int CliqueId { get; set; }
        public int Rating { get; set; }
    }
}
