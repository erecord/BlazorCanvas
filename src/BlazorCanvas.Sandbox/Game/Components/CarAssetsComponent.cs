using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Assets;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;

namespace BlazorCanvas.Example11.Game.Components
{
    public class CarAssetsComponent : BaseComponent
    {
        private SpriteRenderComponent _spriteRenderComponent;
        private BoundingBoxComponent _spriteBoundingBoxComponent;
        private Dictionary<CarStateEnum, string> _carStateAssetDictionary;

        private CarStateEnum CarState => (Owner as CarObject).State;
        private string _selectedAssetPath;

        public CarAssetsComponent(GameObject owner) : base(owner)
        {
            _spriteRenderComponent = owner.Components.Get<SpriteRenderComponent>();
            _spriteBoundingBoxComponent = owner.Components.Get<BoundingBoxComponent>();

            _carStateAssetDictionary = new Dictionary<CarStateEnum, string>()
            {
                {CarStateEnum.Northbound, "assets/sedanSports_N.png"},
                {CarStateEnum.Southbound, "assets/sedanSports_S.png"},
                {CarStateEnum.Eastbound, "assets/sedanSports_E.png"},
                {CarStateEnum.Westbound, "assets/sedanSports_W.png"},
                {CarStateEnum.NorthEast, "assets/sedanSports_NE.png"},
                {CarStateEnum.NorthWest, "assets/sedanSports_NW.png"},
                {CarStateEnum.SouthEast, "assets/sedanSports_SE.png"},
                {CarStateEnum.SouthWest, "assets/sedanSports_SW.png"}
            };
        }

        public override ValueTask Update(GameContext game)
        {
            var carStateAssetPath = _carStateAssetDictionary[CarState];
            if (_selectedAssetPath != carStateAssetPath)
            {
                _selectedAssetPath = carStateAssetPath;

                var assetsResolver = game.GetService<AssetsResolver>();
                var carSprite = assetsResolver.Get<Sprite>(carStateAssetPath);
                _spriteRenderComponent.Sprite = carSprite;
                _spriteBoundingBoxComponent.SetSize(carSprite.Bounds.Size);
            }
            return new ValueTask();
        }
    }
}