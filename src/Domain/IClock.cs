using System;

namespace LunchPicker.Domain
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }

    public class Clock : IClock
    {
        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }
    }
}
