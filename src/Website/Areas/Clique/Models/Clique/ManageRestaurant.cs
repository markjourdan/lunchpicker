﻿using System.Collections.Generic;
using LunchPicker.Domain.Entities;

namespace LunchPicker.Web.Areas.Clique.Models.Clique
{
    public class ManageRestaurant
    {
        public IEnumerable<State> States { get; set; } 
        public long CliqueId { get; set; }
    }
}