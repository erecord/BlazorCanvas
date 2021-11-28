using BlazorCanvas.Sandbox.Game.Components;

namespace BlazorCanvas.Sandbox.Game.Builders
{
    public class UserControlledCarObjectBuilder : BaseCarObjectBuilder
    {
        public override void SetBehaviour()
        {
            base.SetBehaviour();
            CarObject.Components.Add<CarUserControllerComponent>();
        }
    }
}