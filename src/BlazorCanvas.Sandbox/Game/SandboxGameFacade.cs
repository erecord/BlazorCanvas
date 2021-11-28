using BlazorCanvas.Core;
using BlazorCanvas.Core.Assets;
using BlazorCanvas.Sandbox.Game.Builders;

namespace BlazorCanvas.Sandbox.Game
{
    public class SandboxGameFacade
    {
        public IAssetResolver AssetResolver { get; }
        public InputService InputService { get; }
        public PathFollowerCarObjectBuilder PathFollowerCarObjectBuilder { get; }
        public UserControlledCarObjectBuilder UserControlledCarObjectBuilder { get; }

        public SandboxGameFacade(IAssetResolver assetResolver, InputService inputService,
        PathFollowerCarObjectBuilder pathFollowerCarObjectBuilder, UserControlledCarObjectBuilder userControlledCarObjectBuilder)
        {
            AssetResolver = assetResolver;
            InputService = inputService;
            PathFollowerCarObjectBuilder = pathFollowerCarObjectBuilder;
            UserControlledCarObjectBuilder = userControlledCarObjectBuilder;
        }
    }
}