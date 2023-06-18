using System;

namespace Domain
{
    public class Time
    {
        public event EventHandler TimePassed;

        public void Forward(TimeSpan timeSpan)
        {
            TimePassed(this, EventArgs.Empty);
        }
    }
}