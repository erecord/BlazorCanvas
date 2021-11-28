using BlazorCanvas.Sandbox.Game.Components;

namespace BlazorCanvas.Sandbox.Game.Builders
{
    public class SystemControlledCarObjectBuilder : BaseCarObjectBuilder
    {
        protected TravelToTargetComponent _travelToTargetComponent => CarObject.Components.Get<TravelToTargetComponent>();
        public SystemControlledCarObjectBuilder()
        {
        }
        public override void SetBehaviour()
        {
            CarObject.Components.Add<TravelToTargetComponent>();
        }
    }
}