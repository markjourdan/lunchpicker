using System;

namespace LunchPicker.Domain.DataTransferObject
{
    public class CliqueDto
    {
        public long CliqueId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid FriendlyKey { get; set; }
    }
}
