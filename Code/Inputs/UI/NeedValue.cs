using Domain.Need;
using System;

namespace Inputs.UI
{
    public partial class NeedValue : Godot.ProgressBar
    {
        public void OnTimeTimeout()
        {
            Needs activeSimNeeds = FindUI().FindPlayer().ActiveSimNeeds;

            Value = Convert.ToDouble(
                activeSimNeeds
                    .GetType()
                    .GetProperty(GetParent().Name.ToString())
                    .GetValue(activeSimNeeds));
        }

        private Godot.UI FindUI()
        {
            return GetNode<Godot.UI>("/root/Root/UI");
        }
    }
}