using System;
using System.Numerics;
using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Components
{

    public class TravelToTargetComponent : BaseMoveComponent
    {
        private CarObject Parent => Owner as CarObject;
        private TransformComponent ParentTransform => Parent.Components.Get<TransformComponent>();

        public TravelToTargetComponent(GameObject owner) : base(owner)
        {
            _speed = 0.15f;
            // Parent.Stopped = true;
        }

        public Func<Vector2> GetTargetPositionFunc;
        public override ValueTask Update(GameContext game)
        {
            // if (_gameObjectTarget != null)
            // {
            //     TargetPoint = new Point((int)TargetTransform.World.Position.X, (int)TargetTransform.World.Position.Y);
            // }

            var dx = ParentTransform.World.Position.X - GetTargetPositionFunc?.Invoke().X;
            var dy = ParentTransform.World.Position.Y - GetTargetPositionFunc?.Invoke().Y;

            var parentIsMoreEastThanTarget = dx > 0;
            var parentIsMoreWestThanTarget = dx < 0;
            var parentIsMoreSouthThanTarget = dy > 0;
            var parentIsMoreNorthThanTarget = dy < 0;

            const int alignmentTolerance = 60;

            var parentIsYAlignedWithTarget = dx < alignmentTolerance && dx > -alignmentTolerance;
            var parentIsXAlignedWithTarget = dy < alignmentTolerance && dy > -alignmentTolerance;

            var parentIsMoreNorthWestThanTarget = parentIsMoreNorthThanTarget && parentIsMoreWestThanTarget;
            var parentIsMoreNorthEastThanTarget = parentIsMoreNorthThanTarget && parentIsMoreEastThanTarget;

            var parentIsMoreSouthWestThanTarget = parentIsMoreSouthThanTarget && parentIsMoreWestThanTarget;
            var parentIsMoreSouthEastThanTarget = parentIsMoreSouthThanTarget && parentIsMoreEastThanTarget;

            // Handle diagonals
            if (parentIsMoreNorthWestThanTarget)
            {
                Parent.State = CarState.SouthEast;
            }
            else if (parentIsMoreNorthEastThanTarget)
            {
                Parent.State = CarState.SouthWest;
            }
            else if (parentIsMoreSouthWestThanTarget)
            {
                Parent.State = CarState.NorthEast;
            }
            else if (parentIsMoreSouthEastThanTarget)
            {
                Parent.State = CarState.NorthWest;
            }

            // Handle straight lines if aligned on the same axis
            if (parentIsMoreNorthThanTarget && parentIsYAlignedWithTarget)
            {
                Parent.State = CarState.Southbound;
            }
            else if (parentIsMoreSouthThanTarget && parentIsYAlignedWithTarget)
            {
                Parent.State = CarState.Northbound;
            }
            else if (parentIsMoreEastThanTarget && parentIsXAlignedWithTarget)
            {
                Parent.State = CarState.Westbound;
            }
            else if (parentIsMoreWestThanTarget && parentIsXAlignedWithTarget)
            {
                Parent.State = CarState.Eastbound;
            }

            base.Update(game);

            return new ValueTask();
        }
    }
}