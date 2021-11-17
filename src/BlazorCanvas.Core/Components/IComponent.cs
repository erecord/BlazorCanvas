using System.Threading.Tasks;

namespace BlazorCanvas.Core.Components
{
    public interface IComponent
    {
        ValueTask Update(GameContext game);

        GameObject Owner { get; }
    }
}