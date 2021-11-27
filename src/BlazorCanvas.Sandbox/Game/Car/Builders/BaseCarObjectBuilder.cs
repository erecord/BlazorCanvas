using System.Drawing;
using System.Numerics;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Example11.Game.Components;
using BlazorCanvas.Sandbox.Core;

public abstract class BaseCarObjectBuilder
{
    protected CarObject CarObject = new CarObject();
    public BaseCarObjectBuilder()
    {
        CarObject.Components.Add<BoundingBoxComponent>();
        CarObject.Components.Add<SpriteRenderComponent>();
        CarObject.Components.Add<CarAssetsComponent>();

        SetCarState(CarStateEnum.Eastbound);
        SetPosition(new Vector2(100, 200));
    }

    public virtual void SetBehaviour()
    {
        CarObject.Components.Add<BaseMoveComponent>();
    }
    public BaseCarObjectBuilder SetPosition(Vector2 newPosition)
    {
        CarObject.SetPosition(newPosition);
        return this;
    }
    public void SetCarState(CarStateEnum carState) => CarObject.State = carState;
    public CarObject Build()
    {
        SetBehaviour();
        return CarObject;
    }
}