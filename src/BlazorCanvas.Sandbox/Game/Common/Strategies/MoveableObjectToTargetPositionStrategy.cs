using System.Numerics;
using BlazorCanvas.Core.Interfaces;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.Components;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Strategies
{
    public class MoveableObjectToTargetPositionStrategy : ITravelToTargetPositionStrategy
    {
        private readonly MoveableGameObject _moveableGameObject;

        public MoveableObjectToTargetPositionStrategy(MoveableGameObject moveableGameObject)
        {
            _moveableGameObject = moveableGameObject;
        }

        public void TravelToTargetPosition(Vector2 currentPosition, Vector2 targetPosition)
        {
            var dx = currentPosition.X - targetPosition.X;
            var dy = currentPosition.Y - targetPosition.Y;

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
                _moveableGameObject.CurrentDirection = DirectionState.SouthEast;
            }
            else if (parentIsMoreNorthEastThanTarget)
            {
                _moveableGameObject.CurrentDirection = DirectionState.SouthWest;
            }
            else if (parentIsMoreSouthWestThanTarget)
            {
                _moveableGameObject.CurrentDirection = DirectionState.NorthEast;
            }
            else if (parentIsMoreSouthEastThanTarget)
            {
                _moveableGameObject.CurrentDirection = DirectionState.NorthWest;
            }

            // Handle straight lines if aligned on the same axis
            if (parentIsMoreNorthThanTarget && parentIsYAlignedWithTarget)
            {
                _moveableGameObject.CurrentDirection = DirectionState.Southbound;
            }
            else if (parentIsMoreSouthThanTarget && parentIsYAlignedWithTarget)
            {
                _moveableGameObject.CurrentDirection = DirectionState.Northbound;
            }
            else if (parentIsMoreEastThanTarget && parentIsXAlignedWithTarget)
            {
                _moveableGameObject.CurrentDirection = DirectionState.Westbound;
            }
            else if (parentIsMoreWestThanTarget && parentIsXAlignedWithTarget)
            {
                _moveableGameObject.CurrentDirection = DirectionState.Eastbound;
            }
        }

    }
}