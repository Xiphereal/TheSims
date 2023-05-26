namespace Domain.Furniture
{
    public class Shower : IUsable
    {
        public void Use(Sim user)
        {
            user.RestoreHygiene();
        }
    }
}