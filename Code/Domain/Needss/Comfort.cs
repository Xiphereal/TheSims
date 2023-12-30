namespace Domain.Needings
{
    internal class Comfort : Need
    {
        public Comfort(int comfort) : base(comfort)
        {
        }

        public override int Increment => 3;
    }
}