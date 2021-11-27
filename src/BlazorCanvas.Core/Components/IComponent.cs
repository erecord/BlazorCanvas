using System.Threading.Tasks;

namespace BlazorCanvas.Core.Components
{
    public interface IComponent
    {
        bool Started { get; }
        ValueTask Update(GameContext game);
        void OnStart(GameContext game);

        GameObject Owner { get; }
    }
}