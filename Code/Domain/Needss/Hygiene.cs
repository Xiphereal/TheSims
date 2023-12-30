namespace Domain.Needings
{
    internal class Hygiene : Need
    {
        public Hygiene(int hygiene) : base(hygiene)
        {
        }

        public override int Increment => 2;
    }
}