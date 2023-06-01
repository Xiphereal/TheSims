namespace Domain.Tests.Builders
{
    internal class LotBuilder
    {
        private Time time;
        private CommandIssuer player;

        private LotBuilder()
        {
            time = new Time();
            player = new CommandIssuer();
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