using BlazorCanvas.Example11.Core;
using BlazorCanvas.Example11.Core.Assets;
using BlazorCanvas.Example11.Core.Components;
using BlazorCanvas.Example11.Game.Components;

public class CarObject : GameObject
{
    private IAssetsResolver _assetsResolver;

    public CarObject(IAssetsResolver assetsResolver)
    {
        _assetsResolver = assetsResolver;

        Components.Add<TransformComponent>();
        Components.Add<BoundingBoxComponent>();
        Components.Add<SpriteRenderComponent>();
        Components.Add<CarBrain>();

        SetEastboundAsset();
        SetPosition(100, 700);
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


    private CarObject SetAsset(string assetPath)
    {
        var spriteRenderComponent = Components.Get<SpriteRenderComponent>();
        var sprite = _assetsResolver.Get<Sprite>(assetPath);
        spriteRenderComponent.Sprite = sprite;

        var bbox = Components.Get<BoundingBoxComponent>();
        bbox.SetSize(sprite.Bounds.Size);

        return this;
    }

    public CarObject SetPosition(float x, float y)
    {
        var transformComponent = Components.Get<TransformComponent>();
        transformComponent.SetPosition(x, y);
        return this;
    }
}