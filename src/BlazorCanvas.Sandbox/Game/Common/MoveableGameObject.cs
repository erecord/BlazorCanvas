using System;
using System.Drawing;
using System.Numerics;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;

namespace BlazorCanvas.Sandbox.Game.Components
{
    public class MoveableGameObject : GameObject
    {
        private TransformComponent _transformComponent => Components.Get<TransformComponent>();
        private Point _position;
        public Vector2 Position
        {
            get => Components.Get<TransformComponent>().World.Position;
            set => _transformComponent.SetPosition(value);

        }
        public MoveableGameObject()
        {
            Components.Add<TransformComponent>();
        }

        public void SetPosition(Vector2 newPosition)
        {
            var transformComponent = Components.Get<TransformComponent>();
            transformComponent.SetPosition(newPosition);
        }

        public Func<Vector2> TargetPositionCallback
        {
            get => Components.Get<TravelToTargetComponent>()?.GetTargetPositionFunc;
            set
            {
                var travelToTargetComponent = Components.Get<TravelToTargetComponent>();
                if (travelToTargetComponent != null)
                {
                    travelToTargetComponent.GetTargetPositionFunc = value;
                }
            }
        }


    }

}