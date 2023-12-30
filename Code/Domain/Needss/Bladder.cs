namespace Domain.Needss
{
    internal class Bladder : Need
    {
        public Bladder(int bladder) : base(bladder)
        {
        }

        public override int Increment => 3;
    }
}