using BlazorCanvas.Example11.Game.Components;

public class UserControlledCarObjectBuilder : BaseCarObjectBuilder
{
    public override void SetBehaviour()
    {
        base.SetBehaviour();
        CarObject.Components.Add<CarUserControllerComponent>();
    }
}