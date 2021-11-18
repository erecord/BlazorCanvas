using System.Drawing;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Example11.Game.Components;
using BlazorCanvas.Sandbox.Core;

public class CarObject : GameObject
{
    public CarStateEnum State { get; set; }
    public bool Stopped { get; set; }

    public CarObject()
    {
        Components.Add<TransformComponent>();
        Components.Add<BoundingBoxComponent>();
        Components.Add<SpriteRenderComponent>();
        Components.Add<CarAssetsComponent>();

        SetPosition(new Point(0, 0));
    }

    public CarObject SetManualCarBrain()
    {
        Components.Add<CarBrain>();
        Components.Add<CarInputController>();
        return this;
    }

    public CarObject SetFollowCarBrain()
    {
        Components.Add<CarFollowComponent>();
        return this;
    }

    public CarObject SetAutomaticCarBrain(CarStateEnum initialState)
    {
        var carBrain = Components.Add<CarBrainAutomatic>();
        State = initialState;
        return this;
    }

    public CarObject SetPosition(Point position)
    {
        var transformComponent = Components.Get<TransformComponent>();
        transformComponent.SetPosition(position);
        return this;
    }
}