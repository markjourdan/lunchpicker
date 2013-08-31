﻿namespace LunchPicker.Web.Models.Home
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
        public long CliqueId { get; set; }
    }
}