using System.Threading.Tasks;

namespace BlazorCanvas.Core.Assets
{
    public interface IAssetResolver : IGameService
    {
        ValueTask<TA> Load<TA>(string path) where TA : IAsset;
        TA Get<TA>(string path) where TA : class, IAsset;
    }
}