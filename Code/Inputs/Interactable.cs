using Control;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Action = Domain.Actions.Action;

namespace Godot
{
    public partial class Interactable : Node3D
    {
        private Player player;

        public override void _Ready()
        {
            player = new Player();
        }

        public override void _Input(InputEvent @event)
        {
            if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
                RemovePreviousOptions();
        }

        private void RemovePreviousOptions()
        {
            GetChildren().OfType<Button>().ToList().ForEach(x => x.QueueFree());
        }

        public void OnAreaInputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shapeIdx)
        {
            if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
            {
                IEnumerable<Action> options = player.InteractWith(GetInteractable());
                DistributeAroundMouse(options);
            }
        }

        protected virtual IInteractable GetInteractable()
        {
            throw new NotImplementedException("This should be overridden");
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

                return GetViewport().GetMousePosition()
                    + new Vector2(Radius * Mathf.Cos(angle), Radius * Mathf.Sin(angle));
            }

            void AddActionButtonAsChild(Action @for, Vector2 at)
            {
                ActionButton button = new()
                {
                    Text = @for.ToString(),
                    Position = at,
                };

                button.Pressed += RemovePreviousOptions;
                button.Pressed += () => CommandToActiveSim(@for);

                AddChild(button);
            }
        }

        private void CommandToActiveSim(Action action)
        {
            AddChild(new TextureRect()
            {
                Texture = GetImageForAction()
            });

            player.Command(action);
        }

        protected virtual Texture2D GetImageForAction()
        {
            throw new NotImplementedException("This should be overridden");
        }
    }
}