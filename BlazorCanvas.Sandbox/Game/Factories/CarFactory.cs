using BlazorCanvas.Example11.Core.Assets;

static class CarFactory
{
    static public CarObject CreateCar(IAssetsResolver assetsResolver) => new CarObject(assetsResolver);
}