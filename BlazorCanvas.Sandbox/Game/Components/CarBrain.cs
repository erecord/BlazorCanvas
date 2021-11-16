using System.Threading.Tasks;
using System.Timers;
using BlazorCanvas.Example11.Core;
using BlazorCanvas.Example11.Core.Components;

namespace BlazorCanvas.Example11.Game.Components
{
    public class CarBrain : BaseComponent
    {
        private TransformComponent Transform => Parent.Components.Get<TransformComponent>();
        private BoundingBoxComponent BoundingBox => Parent.Components.Get<BoundingBoxComponent>();
        private InputService InputService;

        // private CarObject GetOwner()
        // {
        //     return Owner as CarObject;
        // }

        private CarObject Parent => this.Owner as CarObject;

        public float _speed = 0.1000f;
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
            // _timer.Start();
        }

        void onElapsed(object sender, ElapsedEventArgs e)
        {
            _carStopped = !_carStopped;
        }

        public override ValueTask Update(GameContext game)
        {
            InputService = game.GetService<InputService>();

            // if (!_carStopped)
            // {
            //     TravelRight(game);
            // }

            if (InputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
            {
                TravelRight(game);
            }
            else if (InputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
            {
                TravelLeft(game);
            }
            else if (InputService.GetKeyState(Keys.Up).State == ButtonState.States.Down)
            {
                TravelUp(game);
            }
            else if (InputService.GetKeyState(Keys.Down).State == ButtonState.States.Down)
            {
                TravelDown(game);
            }

            return new ValueTask();
        }

        private void TravelRight(GameContext game)
        {
            Transform.Local.Position.X += _speed * game.GameTime.ElapsedMilliseconds;
            Parent.SetEastboundAsset();
        }

        private void TravelLeft(GameContext game)
        {
            Transform.Local.Position.X -= _speed * game.GameTime.ElapsedMilliseconds;
            Parent.SetWestboundAsset();
        }

        private void TravelUp(GameContext game)
        {
            Transform.Local.Position.Y -= _speed * game.GameTime.ElapsedMilliseconds;
            Parent.SetNorthboundAsset();
        }

        private void TravelDown(GameContext game)
        {
            Transform.Local.Position.Y += _speed * game.GameTime.ElapsedMilliseconds;
            Parent.SetSouthboundAsset();
        }

    }
}