namespace Domain.Tests.Builders
{
    public class LotBuilder
    {
        private Time time;

        private LotBuilder()
        {
            time = new Time();
        }

        public static LotBuilder Lot() => new();

        public LotBuilder With(Time time)
        {
            this.time = time;

            return this;
        }

        public Lot Build()
        {
            return new Lot(time);
        }
    }
}