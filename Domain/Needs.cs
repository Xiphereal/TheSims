namespace Domain
{
    public class Needs
    {
        private const int NeedMaxValue = 100;
        private int hunger;

        public int Hunger
        {
            get => hunger;
            set
            {
                hunger = value > NeedMaxValue ? NeedMaxValue : value;
            }
        }

        public int Hygiene { get; set; }
        public int Bladder { get; set; }
        public int Energy { get; set; }
        public int Comfort { get; set; }

        public Needs(int hunger, int hygiene, int bladder, int energy, int confort)
        {
            Hunger = hunger;
            Hygiene = hygiene;
            Bladder = bladder;
            Energy = energy;
            Comfort = confort;
        }
    }
}