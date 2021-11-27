using System;
using System.Threading.Tasks;

namespace BlazorCanvas.Core.Components
{
    public abstract class BaseComponent : IComponent
    {
        public bool Started { get; private set; }
        protected BaseComponent(GameObject owner)
        {
            this.Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public virtual void OnStart(GameContext game)
        {
            Started = true;
        }

        public virtual ValueTask Update(GameContext game)
        {
            return new ValueTask();
        }

        public GameObject Owner { get; }
    }
}