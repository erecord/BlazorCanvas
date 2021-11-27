using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Core.Enums;
using BlazorCanvas.Sandbox.GameObjects;

public class CarObject : MoveableGameObject
{
    public CarStateEnum State { get; set; }
    public bool Stopped { get; set; }

    public CarObject Create(BaseCarObjectBuilder carObjectBuilder) => carObjectBuilder.Build();

    // public CarObject SetManualCarBrain()
    // {
    //     Components.Add<BaseMoveComponent>();
    //     Components.Add<CarUserControllerComponent>();
    //     return this;
    // }

    // public CarObject SetFollowCarBrain()
    // {
    //     Components.Add<CarFollowComponent>();
    //     return this;
    // }

    // public CarObject SetAutomaticCarBrain(CarStateEnum initialState)
    // {
    //     var carBrain = Components.Add<CarBrainAutomatic>();
    //     State = initialState;
    //     return this;
    // }

    private void onTrafficLightStateChanged(object sender, TrafficLightState newTrafficLightState)
    {
        if (newTrafficLightState == TrafficLightState.Green)
        {
            Stopped = false;
        }
    }
    public void SubscribeToTrafficLight(TrafficLightObject trafficLight)
    {
        trafficLight.TrafficLightStateChanged += onTrafficLightStateChanged;
    }

}