using System;
using BlazorCanvas.Core;
using BlazorCanvas.Sandbox.Core.Enums;

namespace BlazorCanvas.Sandbox.GameObjects
{
    public class TrafficLightObject : GameObject
    {
        private TrafficLightState _trafficLightState;
        public TrafficLightState TrafficLightState
        {
            get => _trafficLightState;
            set
            {
                _trafficLightState = value;
                TrafficLightStateChanged?.Invoke(this, _trafficLightState);
            }
        }

        public event EventHandler<TrafficLightState> TrafficLightStateChanged;
    }
}