using System;

namespace Domain
{
    public class Time
    {
        public event EventHandler TimePassed;

        public void Forward()
        {
            TimePassed(this, EventArgs.Empty);
        }
    }
}