using Control;
using Domain.Actions;
using System.Collections.Generic;
using System.Linq;

namespace Godot
{
    public partial class UI : Godot.Control
    {
        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
                RemovePreviousOptions();
        }

        private void RemovePreviousOptions()
        {
            GetChildren().OfType<Button>().ToList().ForEach(x => x.QueueFree());
        }

        public void DistributeAroundMouse(IEnumerable<Action> options, Texture2D imageForIcons)
        {
            for (int i = 0; i < options.Count(); i++)
                CreateActionButton(@for: options.ElementAt(i), at: CalculatePosition(options, i));

            Vector2 CalculatePosition(IEnumerable<Action> options, int i)
            {
                float angleBetweenOptions = 360f / options.Count();
                float angle = Mathf.DegToRad(angleBetweenOptions * i);

                const float Radius = 100f;

                return GetViewport().GetMousePosition()
                    + new Vector2(Radius * Mathf.Cos(angle), Radius * Mathf.Sin(angle));
            }

            void CreateActionButton(Action @for, Vector2 at)
            {
                ActionButton button = new()
                {
                    Text = @for.ToString(),
                    Position = at,
                };

                button.Pressed += RemovePreviousOptions;
                button.Pressed += () => CommandToActiveSim(@for, imageForIcons);

                AddChild(button);
            }
        }

        private void CommandToActiveSim(Action action, Texture2D imageForIcons)
        {
            Button button = new() { Icon = imageForIcons };
            button.Pressed += () =>
            {
                button.QueueFree();
                FindPlayer().Cancel(action);
            };

            GetNode<Control>("./ActionsQueue").AddChild(button);

            FindPlayer().Command(action);
        }

        private Player FindPlayer()
        {
            return GetNode<PlayerInput>("../Player").Player;
        }
    }
}