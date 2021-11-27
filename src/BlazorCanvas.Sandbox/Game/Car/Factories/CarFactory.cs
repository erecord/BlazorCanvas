using BlazorCanvas.Sandbox.Core;

static class CarFactory
{
    static public CarObject CreateUserControlledCar(UserControlledCarObjectBuilder carObjectBuilder) => carObjectBuilder.Build();
    static public SystemControlledCarObjectBuilder CreateSystemControlledCar(SystemControlledCarObjectBuilder carObjectBuilder) => carObjectBuilder;
    static public CarObject CreateCarGoingEast(SystemControlledCarObjectBuilder carObjectBuilder)
    {
        var car = carObjectBuilder.Build();
        car.State = CarStateEnum.Eastbound;

        return car;
    }
    static public CarObject CreateCarGoingWest(SystemControlledCarObjectBuilder carObjectBuilder)
    {
        var car = carObjectBuilder.Build();
        car.State = CarStateEnum.Westbound;

        return car;
    }
    // static public CarObject CreateCarGoingEast() => new CarObject().SetAutomaticCarBrain(CarStateEnum.Eastbound);
    // static public CarObject CreateCarGoingWest() => new CarObject().SetAutomaticCarBrain(CarStateEnum.Westbound);
}