using System;
using System.Drawing;
using System.Numerics;
using BlazorCanvas.Example11.Game.Components;
using BlazorCanvas.Sandbox.Core;

public class SystemControlledCarObjectBuilder : BaseCarObjectBuilder
{
    public TravelToTargetComponent _travelToTargetComponent => CarObject.Components.Get<TravelToTargetComponent>();
    public SystemControlledCarObjectBuilder()
    {
        SetCarState(CarStateEnum.Westbound);
    }
    public override void SetBehaviour()
    {
        CarObject.Components.Add<TravelToTargetComponent>();
    }


}