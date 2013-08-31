using System.Collections.Generic;

namespace LunchPicker.Web.Models.Account
{
    public class AccountModel
    {
        public CliqueCreateModel CliqueCreate { get; set; }
        public CliqueJoinModel CliqueJoin { get; set; }
        public LocalPasswordModel LocalPassword { get; set; }

        public ICollection<CliqueModel> Cliques { get; set; }
    }
}