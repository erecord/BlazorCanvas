using BlazorCanvas.Sandbox.Core;

static class CarFactory
{
    static public CarObject CreateCar() => new CarObject().SetManualCarBrain();
    static public CarObject CreateCarGoingEast() => new CarObject().SetAutomaticCarBrain(CarStateEnum.Eastbound);
    static public CarObject CreateCarGoingWest() => new CarObject().SetAutomaticCarBrain(CarStateEnum.Westbound);
}