using System.Threading.Tasks;

namespace BlazorCanvas.Core
{
    public interface IGameService
    {
        ValueTask Step();
    }
}