using System.Numerics;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;

namespace BlazorCanvas.Sandbox.Game.GameObjects
{
    public class MoveableGameObject : GameObject
    {
        private TransformComponent _transformComponent => Components.Get<TransformComponent>();
        public DirectionState CurrentDirection { get; set; }
        public Vector2 Position
        {
            get => Components.Get<TransformComponent>().World.Position;
            set => _transformComponent.SetPosition(value);
        }

        public MoveableGameObject()
        {
            Components.Add<TransformComponent>();
        }

        public void SetPosition(Vector2 newPosition) => _transformComponent.SetPosition(newPosition);

    }

}