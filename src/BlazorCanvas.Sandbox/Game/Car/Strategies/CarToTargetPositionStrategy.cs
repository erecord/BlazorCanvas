using System.Numerics;
using BlazorCanvas.Core.Interfaces;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Strategies
{
    public class CarToTargetPositionStrategy : ITravelToTargetPositionStrategy
    {
        // TODO try refactor by putting a generic direction State in GameObject
        private readonly CarObject _carObject;

        public CarToTargetPositionStrategy(CarObject carObject)
        {
            _carObject = carObject;
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
                _carObject.State = CarState.SouthEast;
            }
            else if (parentIsMoreNorthEastThanTarget)
            {
                _carObject.State = CarState.SouthWest;
            }
            else if (parentIsMoreSouthWestThanTarget)
            {
                _carObject.State = CarState.NorthEast;
            }
            else if (parentIsMoreSouthEastThanTarget)
            {
                _carObject.State = CarState.NorthWest;
            }

            // Handle straight lines if aligned on the same axis
            if (parentIsMoreNorthThanTarget && parentIsYAlignedWithTarget)
            {
                _carObject.State = CarState.Southbound;
            }
            else if (parentIsMoreSouthThanTarget && parentIsYAlignedWithTarget)
            {
                _carObject.State = CarState.Northbound;
            }
            else if (parentIsMoreEastThanTarget && parentIsXAlignedWithTarget)
            {
                _carObject.State = CarState.Westbound;
            }
            else if (parentIsMoreWestThanTarget && parentIsXAlignedWithTarget)
            {
                _carObject.State = CarState.Eastbound;
            }
        }

    }
}