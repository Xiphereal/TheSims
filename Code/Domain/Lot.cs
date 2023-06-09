﻿using System.Collections.Generic;

namespace Domain
{
    public class Lot
    {
        private readonly Time time;
        private readonly List<Sim> sims = new();

        public Lot(Time time)
        {
            this.time = time;
        }

        public void EnteredBy(Sim sim)
        {
            time.TimePassed += (_, _) =>
            {
                sim.PerformNextAction();
                sim.IncreaseNeeds();
            };

            sims.Add(sim);
        }
    }
}