using BlazorCanvas.Core;

namespace BlazorCanvas.Example11.Game.Components
{
    public class CarBrainAutomatic : CarBrain
    {
        private CarObject Parent => Owner as CarObject;

        public CarBrainAutomatic(GameObject owner) : base(owner)
        {
            _speed = 0.1500f;
            Parent.Stopped = false;
        }

    }
}