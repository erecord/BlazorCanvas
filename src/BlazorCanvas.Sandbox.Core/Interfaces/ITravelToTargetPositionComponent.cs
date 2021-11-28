using System.Numerics;
using BlazorCanvas.Core.Interfaces;

namespace BlazorCanvas.Sandbox.Core.Interfaces
{
    public interface ITravelToTargetPositionComponent
    {
        ITravelToTargetPositionStrategy TravelToTargetPositionStrategy { get; set; }
        Vector2? TargetPosition { get; set; }
        Vector2? CurrentPosition { get; set; }
    }
}