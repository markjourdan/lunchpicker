using System;

namespace LunchPicker.Web.Areas.CrunchAdmin.Models.Cliques
{
    public class CliqueModel
    {
        public long CliqueId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid FriendlyKey { get; set; }
    }
}