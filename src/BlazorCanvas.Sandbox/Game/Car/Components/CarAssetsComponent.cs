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
        private Dictionary<CarState, string> _carStateAssetDictionary;

        private CarState CarState => (Owner as CarObject).State;
        private string _selectedAssetPath;

        public CarAssetsComponent(GameObject owner) : base(owner)
        {
            _spriteRenderComponent = owner.Components.Get<SpriteRenderComponent>();
            _spriteBoundingBoxComponent = owner.Components.Get<BoundingBoxComponent>();

            _carStateAssetDictionary = new Dictionary<CarState, string>()
            {
                {CarState.Northbound, "assets/sedanSports_N.png"},
                {CarState.Southbound, "assets/sedanSports_S.png"},
                {CarState.Eastbound, "assets/sedanSports_E.png"},
                {CarState.Westbound, "assets/sedanSports_W.png"},
                {CarState.NorthEast, "assets/sedanSports_NE.png"},
                {CarState.NorthWest, "assets/sedanSports_NW.png"},
                {CarState.SouthEast, "assets/sedanSports_SE.png"},
                {CarState.SouthWest, "assets/sedanSports_SW.png"},
            };

        }

        public override void OnStart(GameContext game)
        {
            base.OnStart(game);

            // Set initial asset
            _selectedAssetPath = _carStateAssetDictionary[CarState.Eastbound];
            updateCarAsset(game, _selectedAssetPath);
        }

        public override ValueTask Update(GameContext game)
        {

            if (CarState != CarState.Stopped)
            {
                var carStateAssetPath = _carStateAssetDictionary[CarState];
                if (_selectedAssetPath != carStateAssetPath)
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