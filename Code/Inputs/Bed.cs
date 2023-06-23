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
                AddActionButtonAsChild(@for: options.ElementAt(i), at: CalculatePosition(options, i));

            Vector2 CalculatePosition(IEnumerable<Action> options, int i)
            {
                float angleBetweenOptions = 360f / options.Count();
                float angle = Mathf.DegToRad(angleBetweenOptions * i);

                const float Radius = 100f;

                Vector2 labelPosition =
                    GetViewport().GetMousePosition()
                        + new Vector2(Radius * Mathf.Cos(angle), Radius * Mathf.Sin(angle));
                return labelPosition;
            }

            void AddActionButtonAsChild(Action @for, Vector2 at)
            {
                ActionButton button = new()
                {
                    Text = @for.ToString(),
                    Position = at,
                };
                button.Pressed += RemovePreviousOptions;
                AddChild(button);
            }
        }
    }
}