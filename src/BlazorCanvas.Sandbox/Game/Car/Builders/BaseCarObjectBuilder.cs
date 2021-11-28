using System.Numerics;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.Components;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Builders
{
    public abstract class BaseCarObjectBuilder
    {
        protected CarObject CarObject = new CarObject();
        public BaseCarObjectBuilder()
        {
            CarObject.Components.Add<BoundingBoxComponent>();
            CarObject.Components.Add<SpriteRenderComponent>();
            CarObject.Components.Add<CarAssetsComponent>();

            SetCarState(DirectionState.Stopped);
            SetPosition(new Vector2(100, 200));
        }

        public virtual void SetBehaviour()
        {
            CarObject.Components.Add<BaseMoveComponent>();
        }
        public BaseCarObjectBuilder SetPosition(Vector2 newPosition)
        {
            CarObject.SetPosition(newPosition);
            return this;
        }
        public void SetCarState(DirectionState newDirection) => CarObject.CurrentDirection = newDirection;
        public CarObject Build()
        {
            SetBehaviour();
            return CarObject;
        }
    }
}