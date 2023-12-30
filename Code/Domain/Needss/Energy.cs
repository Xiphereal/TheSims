namespace Domain.Needss
{
    internal class Energy : Need
    {
        public Energy(int energy) : base(energy)
        {
        }

        public override int Increment => 1;
    }
}