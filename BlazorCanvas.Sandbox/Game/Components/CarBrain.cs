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
        private CarObject Parent => this.Owner as CarObject;

        public float _speed = 0.6000f;
        private bool _carStopped = false;

        private Timer _timer = new Timer();

        private CarBrain(GameObject owner) : base(owner)
        {
            BoundingBox.OnCollision += (sender, collidedWith) =>
            {
                // check if we're colliding with another car
                if (!collidedWith.Owner.Components.TryGet<CarBrain>(out var _))
                    this.Owner.Enabled = false;
            };
        }


        public override ValueTask Update(GameContext game)
        {
            var inputService = game.GetService<InputService>();

            if (inputService.GetKeyState(Keys.Up).State == ButtonState.States.Down)
            {
                if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
                {

                    TravelNorthEast(game);
                    Parent.SetNorthEastAsset();
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {

                    TravelNorthWest(game);
                    Parent.SetNorthWestAsset();
                }
                else
                {

                    TravelNorth(game);
                    Parent.SetNorthboundAsset();
                }
            }

            else if (inputService.GetKeyState(Keys.Down).State == ButtonState.States.Down)
            {
                if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
                {

                    TravelSouthEast(game);
                    Parent.SetSouthEastAsset();
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {

                    TravelSouthWest(game);
                    Parent.SetSouthWestAsset();
                }
                else
                {

                    TravelSouth(game);
                    Parent.SetSouthboundAsset();
                }
            }

            else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
            {
                TravelWest(game);
                Parent.SetWestboundAsset();
            }

            else if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
            {
                TravelEast(game);
                Parent.SetEastboundAsset();
            }


            return new ValueTask();
        }

        private void TravelEast(GameContext game)
        {
            Transform.Local.Position.X += _speed * game.GameTime.ElapsedMilliseconds;
        }

        private void TravelWest(GameContext game)
        {
            Transform.Local.Position.X -= _speed * game.GameTime.ElapsedMilliseconds;
        }

        private void TravelNorth(GameContext game)
        {
            Transform.Local.Position.Y -= _speed * game.GameTime.ElapsedMilliseconds;
        }

        private void TravelSouth(GameContext game)
        {
            Transform.Local.Position.Y += _speed * game.GameTime.ElapsedMilliseconds;
        }

        private void TravelNorthEast(GameContext game)
        {
            TravelNorth(game);
            TravelEast(game);
        }

        private void TravelNorthWest(GameContext game)
        {
            TravelNorth(game);
            TravelWest(game);
        }

        private void TravelSouthEast(GameContext game)
        {
            TravelSouth(game);
            TravelEast(game);
        }

        private void TravelSouthWest(GameContext game)
        {
            TravelSouth(game);
            TravelWest(game);
        }

    }
}