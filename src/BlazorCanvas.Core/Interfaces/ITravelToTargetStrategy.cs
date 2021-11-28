using System.Numerics;

namespace BlazorCanvas.Core.Interfaces
{
    public interface ITravelToTargetPositionStrategy
    {
        void TravelToTargetPosition(Vector2 currentPosition, Vector2 targetPosition);
    }
}