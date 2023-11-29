using System;

namespace Domain
{
    public class Time
    {
        public event EventHandler TimePassed;

        public void Forward(int howMuch = 1)
        {
            for (int i = 0; i < howMuch; i++)
                TimePassed(this, EventArgs.Empty);
        }
    }
}