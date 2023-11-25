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
        private void RemovePreviousOptions()
        {
            FindUI().GetChildren().OfType<Button>().ToList()
                .ForEach(x => x.QueueFree());
        }

        private UI FindUI()
        {
            return GetNode<UI>("/root/Root/UI");
        }

        public void OnAreaInputEvent(
            Node camera,
            InputEvent @event,
            Vector3 position,
            Vector3 normal,
            long shapeIdx)
        {
            if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
            {
                IEnumerable<Action> options = FindPlayer()
                    .InteractWith(GetInteractable());

                FindUI().DistributeAroundMouse(
                    options,
                    imageForIcons: GetImageForAction());
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

        protected virtual Texture2D GetImageForAction()
        {
            throw new NotImplementedException("This should be overridden");
        }
    }
}