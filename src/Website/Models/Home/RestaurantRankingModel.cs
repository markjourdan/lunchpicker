using System.Collections.Generic;
using LunchPicker.Domain.DataTransferObject;

namespace LunchPicker.Web.Models.Home
{
    public class RestaurantRankingModel
    {
        public List<CliqueDto> Cliques { get; set; } 
    }
}