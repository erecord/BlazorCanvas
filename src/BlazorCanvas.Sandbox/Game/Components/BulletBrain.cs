using System.Threading.Tasks;
using Blazor.Extensions;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;

namespace BlazorCanvas.Example11.Game.Components
{
    public class BulletBrain : BaseComponent
    {
        private readonly MovingBody _movingBody;
        private readonly TransformComponent _transformComponent;

        public BulletBrain(GameObject owner) : base(owner)
        {
            _movingBody = owner.Components.Get<MovingBody>();
            _transformComponent = owner.Components.Get<TransformComponent>();
        }

        public override ValueTask Update(GameContext game)
        {
            _movingBody.Thrust = Speed;

            var isOutScreen = _transformComponent.World.Position.X < 0 ||
                              _transformComponent.World.Position.Y < 0 ||
                              _transformComponent.World.Position.X > Canvas.Width ||
                              _transformComponent.World.Position.Y > Canvas.Height;
            if (isOutScreen)
                Owner.Enabled = false;
            return new ValueTask();
        }

        public float Speed { get; set; }
        public BECanvasComponent Canvas { get; set; }
    }
}