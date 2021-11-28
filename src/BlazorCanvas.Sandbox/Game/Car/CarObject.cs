using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Core.Enums;
using BlazorCanvas.Sandbox.Game.Components;

namespace BlazorCanvas.Sandbox.Game.GameObjects
{
    public class CarObject : MoveableGameObject
    {
        public CarState State { get; set; }

        private void onTrafficLightStateChanged(object sender, TrafficLightState newTrafficLightState)
        {
            if (newTrafficLightState == TrafficLightState.Green)
            {
                // Stopped = false;
            }
        }
        public void SubscribeToTrafficLight(TrafficLightObject trafficLight)
        {
            trafficLight.TrafficLightStateChanged += onTrafficLightStateChanged;
        }

    }
}