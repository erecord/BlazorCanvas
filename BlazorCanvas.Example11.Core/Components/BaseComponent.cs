using System;
using System.Threading.Tasks;

namespace BlazorCanvas.Example11.Core.Components
{
    public abstract class BaseComponent : IComponent
    {
        protected BaseComponent(GameObject owner)
        {
            this.Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        //TODO: add an OnStart method

        public virtual ValueTask Update(GameContext game)
        {
            return new ValueTask();
        }

        public GameObject Owner { get; }
    }
}