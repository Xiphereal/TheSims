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
        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
                RemovePreviousOptions();
        }

        private void RemovePreviousOptions()
        {
            FindUI().GetChildren().OfType<Button>().ToList().ForEach(x => x.QueueFree());
        }

        private Control FindUI()
        {
            return GetNode<Control>("/root/Root/UI");
        }

        public void OnAreaInputEvent(Node camera, InputEvent @event, Vector3 position, Vector3 normal, long shapeIdx)
        {
            if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
            {
                IEnumerable<Action> options = FindPlayer().InteractWith(GetInteractable());
                DistributeAroundMouse(options);
            }
        }

        private Player FindPlayer()
        {
            return GetNode<PlayerInput>("../Player").Player;
        }

        protected virtual IInteractable GetInteractable()
        {
            throw new NotImplementedException("This should be overridden");
        }

        private void DistributeAroundMouse(IEnumerable<Action> options)
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
                button.Pressed += () => CommandToActiveSim(@for);

                FindUI().AddChild(button);
            }
        }

        private void CommandToActiveSim(Action action)
        {
            Button button = new()
            {
                Icon = GetImageForAction()
            };
            button.Pressed += () =>
            {
                button.QueueFree();
                FindPlayer().Cancel(action);
            };

            FindActionsQueue().AddChild(button);

            FindPlayer().Command(action);
        }

        private Control FindActionsQueue()
        {
            return GetNode<Control>("/root/Root/UI/ActionsQueue");
        }

        protected virtual Texture2D GetImageForAction()
        {
            throw new NotImplementedException("This should be overridden");
        }
    }
}