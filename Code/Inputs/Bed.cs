using Control;
using Domain.Actions;
using System.Collections.Generic;
using System.Linq;

namespace Godot
{
    public partial class Bed : Node3D
    {
        private Player player;

        public override void _Ready()
        {
            player = new Player();
        }

        public void OnAreaInputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shapeIdx)
        {
            if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
            {
                // TODO: Move this to be always called on any mouse click, not only on this Area.
                RemovePreviousOptions();

                IEnumerable<IAction> options = player.InteractWith(new Domain.Furniture.Bed());
                DistributeAroundMouse(options);
            }
        }

        private void RemovePreviousOptions()
        {
            GetChildren().OfType<Label>().ToList().ForEach(x => x.QueueFree());
        }

        private void DistributeAroundMouse(IEnumerable<IAction> options)
        {
            for (int i = 0; i < options.Count(); i++)
            {
                float angleBetweenOptions = 360f / options.Count();
                float angle = Mathf.DegToRad(angleBetweenOptions * i);

                const float Radius = 100f;

                Vector2 labelPosition =
                    GetViewport().GetMousePosition()
                    + new Vector2(Radius * Mathf.Cos(angle), Radius * Mathf.Sin(angle));

                // With the given approach, the options do not appear centered at the mouse, but
                // with an offset to the right. I have no idea why.
                labelPosition = FixOffset(labelPosition);

                AddChild(new Label
                {
                    Text = options.ElementAt(i).ToString(),
                    Position = labelPosition,
                });
            }

            static Vector2 FixOffset(Vector2 labelPosition)
            {
                labelPosition += Vector2.Left * 75;
                labelPosition += Vector2.Up * 10;

                return labelPosition;
            }
        }
    }
}