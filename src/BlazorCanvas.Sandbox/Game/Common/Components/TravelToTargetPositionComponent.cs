using System.Numerics;
using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Core.Interfaces;
using BlazorCanvas.Sandbox.Core.Interfaces;

namespace BlazorCanvas.Sandbox.Game.Components
{

    public class TravelToTargetPositionComponent : BaseMoveComponent, ITravelToTargetPositionComponent
    {
        private ITransformComponent _transformComponent => Owner.Components.Get<TransformComponent>();
        public ITravelToTargetPositionStrategy TravelToTargetPositionStrategy { get; set; }
        public Vector2? TargetPosition { get; set; }


        public Vector2? CurrentPosition
        {
            get => _transformComponent.World.Position;
            set => _transformComponent.World.Position = value.Value;
        }


        public TravelToTargetPositionComponent(GameObject owner) : base(owner)
        {
            _speed = 0.15f;
        }

        public override ValueTask Update(GameContext game)
        {
            if (CurrentPosition.HasValue && TargetPosition.HasValue)
            {
                TravelToTargetPositionStrategy?.TravelToTargetPosition(CurrentPosition.Value, TargetPosition.Value);
            }

            base.Update(game);

            return new ValueTask();
        }
    }
}