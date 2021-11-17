using BlazorCanvas.Example11.Core.Assets;

static class CarFactory
{
    static public CarObject CreateCar(IAssetsResolver assetsResolver) => new CarObject(assetsResolver).SetManualCarBrain();
    static public CarObject CreateCarGoingEast(IAssetsResolver assetsResolver)
    => new CarObject(assetsResolver).SetAutomaticCarBrain(BlazorCanvas.Example11.Game.Components.CarBrainAutomatic.CarStates.Eastbound);

    static public CarObject CreateCarGoingWest(IAssetsResolver assetsResolver)
    => new CarObject(assetsResolver).SetAutomaticCarBrain(BlazorCanvas.Example11.Game.Components.CarBrainAutomatic.CarStates.Westbound);
}