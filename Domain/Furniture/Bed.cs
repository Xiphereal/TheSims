namespace Domain.Furniture
{
    public class Bed : IUsable
    {
        public void Use(Sim user)
        {
            user.Sleep();
        }
    }
}