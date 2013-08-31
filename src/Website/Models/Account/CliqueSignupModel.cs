using System.ComponentModel.DataAnnotations;

namespace LunchPicker.Web.Models.Account
{
    public class CliqueJoinModel
    {
        [Required]
        [Display(Name = "Clique's Join Key")]
        public string CliqueKey { get; set; }
    }

    public class CliqueCreateModel
    {
        [Required]
        [Display(Name = "Clique Name")]
        public string CliqueName { get; set; }
    }
}