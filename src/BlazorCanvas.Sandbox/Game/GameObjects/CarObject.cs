using System.Drawing;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Assets;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Example11.Game.Components;
using BlazorCanvas.Sandbox.Core;

public class CarObject : GameObject
{
    private IAssetsResolver _assetsResolver;

    public CarObject(IAssetsResolver assetsResolver)
    {
        _assetsResolver = assetsResolver;

        Components.Add<TransformComponent>();
        Components.Add<BoundingBoxComponent>();
        Components.Add<SpriteRenderComponent>();

        SetEastboundAsset();
    }

    public CarObject SetManualCarBrain()
    {
        Components.Add<CarBrain>();
        return this;
    }

    public CarObject SetAutomaticCarBrain(CarStateEnum initialState)
    {
        var carBrain = Components.Add<CarBrainAutomatic>();
        carBrain.CarState = initialState;
        return this;
    }

    public CarObject SetNorthboundAsset()
    {
        SetAsset("assets/sedanSports_N.png");
        return this;
    }

    public CarObject SetEastboundAsset()
    {
        SetAsset("assets/sedanSports_E.png");
        return this;
    }

    public CarObject SetSouthboundAsset()
    {
        SetAsset("assets/sedanSports_S.png");
        return this;
    }

    public CarObject SetWestboundAsset()
    {
        SetAsset("assets/sedanSports_W.png");
        return this;
    }

    public CarObject SetNorthEastAsset()
    {
        SetAsset("assets/sedanSports_NE.png");
        return this;
    }

    public CarObject SetNorthWestAsset()
    {
        SetAsset("assets/sedanSports_NW.png");
        return this;
    }

    public CarObject SetSouthEastAsset()
    {
        SetAsset("assets/sedanSports_SE.png");
        return this;
    }

    public CarObject SetSouthWestAsset()
    {
        SetAsset("assets/sedanSports_SW.png");
        return this;
    }


    private CarObject SetAsset(string assetPath)
    {
        var spriteRenderComponent = Components.Get<SpriteRenderComponent>();
        var sprite = _assetsResolver.Get<Sprite>(assetPath);
        spriteRenderComponent.Sprite = sprite;

        var bbox = Components.Get<BoundingBoxComponent>();
        bbox.SetSize(sprite.Bounds.Size);

        return this;
    }

    public CarObject SetPosition(Point position)
    {
        var transformComponent = Components.Get<TransformComponent>();
        transformComponent.SetPosition(position);
        return this;
    }
}