﻿namespace Domain.Furniture
{
    public class Bath : IUsable
    {
        public void Use(Sim user)
        {
            user.RestoreHygiene();
        }
    }
}