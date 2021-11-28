using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Assets;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Components
{
    public class CarAssetsComponent : BaseComponent
    {
        private SpriteRenderComponent _spriteRenderComponent;
        private BoundingBoxComponent _spriteBoundingBoxComponent;
        private Dictionary<DirectionState, string> _carStateAssetDictionary;

        private DirectionState CurrentCarDirection => (Owner as CarObject).CurrentDirection;
        private string _selectedAssetPath;

        public CarAssetsComponent(GameObject owner) : base(owner)
        {
            _spriteRenderComponent = owner.Components.Get<SpriteRenderComponent>();
            _spriteBoundingBoxComponent = owner.Components.Get<BoundingBoxComponent>();

            _carStateAssetDictionary = new Dictionary<DirectionState, string>()
            {
                {DirectionState.Northbound, "assets/sedanSports_N.png"},
                {DirectionState.Southbound, "assets/sedanSports_S.png"},
                {DirectionState.Eastbound, "assets/sedanSports_E.png"},
                {DirectionState.Westbound, "assets/sedanSports_W.png"},
                {DirectionState.NorthEast, "assets/sedanSports_NE.png"},
                {DirectionState.NorthWest, "assets/sedanSports_NW.png"},
                {DirectionState.SouthEast, "assets/sedanSports_SE.png"},
                {DirectionState.SouthWest, "assets/sedanSports_SW.png"},
            };

        }

        public override void OnStart(GameContext game)
        {
            base.OnStart(game);

            // Set initial asset
            _selectedAssetPath = _carStateAssetDictionary[DirectionState.Eastbound];
            updateCarAsset(game, _selectedAssetPath);
        }

        public override ValueTask Update(GameContext game)
        {

            if (CurrentCarDirection != DirectionState.Stopped)
            {
                var carStateAssetPath = _carStateAssetDictionary[CurrentCarDirection];
                var assetChanged = _selectedAssetPath != carStateAssetPath;
                if (assetChanged)
                {
                    _selectedAssetPath = carStateAssetPath;
                    updateCarAsset(game, _selectedAssetPath);
                }
            }
            return new ValueTask();
        }

        private void updateCarAsset(GameContext game, string assetPath)
        {
            var assetsResolver = game.GetService<AssetResolver>();
            var carSprite = assetsResolver.Get<Sprite>(assetPath);
            _spriteRenderComponent.Sprite = carSprite;
            _spriteBoundingBoxComponent.SetSize(carSprite.Bounds.Size);
        }
    }
}