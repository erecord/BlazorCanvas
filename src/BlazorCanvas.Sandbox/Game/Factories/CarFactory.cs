using BlazorCanvas.Core.Assets;
using BlazorCanvas.Sandbox.Core;

static class CarFactory
{
    static public CarObject CreateCar(IAssetsResolver assetsResolver) => new CarObject(assetsResolver).SetManualCarBrain();
    static public CarObject CreateCarGoingEast(IAssetsResolver assetsResolver)
    => new CarObject(assetsResolver).SetAutomaticCarBrain(CarStates.Eastbound);

    static public CarObject CreateCarGoingWest(IAssetsResolver assetsResolver)
    => new CarObject(assetsResolver).SetAutomaticCarBrain(CarStates.Westbound);
}