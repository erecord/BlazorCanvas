using BlazorCanvas.Sandbox.Core.Interfaces;
using BlazorCanvas.Sandbox.Game.Components;
using BlazorCanvas.Sandbox.Game.GameObjects;
using BlazorCanvas.Sandbox.Game.Strategies;

namespace BlazorCanvas.Sandbox.Game.Builders
{
    public class SystemControlledCarObjectBuilder : BaseCarObjectBuilder
    {
        private ITravelToTargetPositionComponent _travelToTargetComponent => CarObject.Components.Get<TravelToTargetPositionComponent>();
        public override void SetBehaviour()
        {
            CarObject.Components.Add<TravelToTargetPositionComponent>();
            _travelToTargetComponent.TravelToTargetPositionStrategy = new MoveableObjectToTargetPositionStrategy(CarObject);
        }

    }
}