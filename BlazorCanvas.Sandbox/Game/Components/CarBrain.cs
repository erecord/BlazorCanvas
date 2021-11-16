using System.Threading.Tasks;
using System.Timers;
using BlazorCanvas.Example11.Core;
using BlazorCanvas.Example11.Core.Components;

namespace BlazorCanvas.Example11.Game.Components
{
    public class CarBrain : BaseComponent
    {
        private TransformComponent Transform => Owner.Components.Get<TransformComponent>();
        private BoundingBoxComponent BoundingBox => Owner.Components.Get<BoundingBoxComponent>();

        public float _speed = 0.0750f;
        private bool _carStopped = false;

        private Timer _timer = new Timer();

        private CarBrain(GameObject owner) : base(owner)
        {
            BoundingBox.OnCollision += (sender, collidedWith) =>
            {
                //     // check if we're colliding with another car
                //     // if (!collidedWith.Owner.Components.TryGet<CarBrain>(out var _))
                //     // this.Owner.Enabled = false;
            };

            _timer.Interval = 5000;
            _timer.Elapsed += onElapsed;
            _timer.Start();
        }

        void onElapsed(object sender, ElapsedEventArgs e)
        {
            _carStopped = !_carStopped;
            (Owner as CarObject).SetNorthboundAsset();
        }

        public override ValueTask Update(GameContext game)
        {

            if (!_carStopped)
            {
                TravelRight(game);
            }


            return new ValueTask();
        }

        private void TravelRight(GameContext game) => Transform.Local.Position.X += _speed * game.GameTime.ElapsedMilliseconds;

    }
}