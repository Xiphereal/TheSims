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

                IEnumerable<Action> options = player.InteractWith(new Domain.Furniture.Bed());
                DistributeAroundMouse(options);
            }
        }

        private void RemovePreviousOptions()
        {
            GetChildren().OfType<Button>().ToList().ForEach(x => x.QueueFree());
        }

        private void DistributeAroundMouse(IEnumerable<Action> options)
        {
            for (int i = 0; i < options.Count(); i++)
            {
                float angleBetweenOptions = 360f / options.Count();
                float angle = Mathf.DegToRad(angleBetweenOptions * i);

                const float Radius = 100f;

                Vector2 labelPosition =
                    GetViewport().GetMousePosition()
                        + new Vector2(Radius * Mathf.Cos(angle), Radius * Mathf.Sin(angle));

                ActionButton button = new()
                {
                    Text = options.ElementAt(i).ToString(),
                    Position = labelPosition,
                };
                button.Pressed += RemovePreviousOptions;
                AddChild(button);
            }
        }
    }
}