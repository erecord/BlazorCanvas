using BlazorCanvas.Sandbox.Game.Components;

namespace BlazorCanvas.Sandbox.Game.Builders
{
    public class PathFollowerCarObjectBuilder : SystemControlledCarObjectBuilder
    {
        public override void SetBehaviour()
        {
            base.SetBehaviour();
            CarObject.Components.Add<PathComponent>();
        }

    }
}