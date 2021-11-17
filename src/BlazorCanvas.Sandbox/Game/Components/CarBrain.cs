using System.Threading.Tasks;
using System.Timers;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;

namespace BlazorCanvas.Example11.Game.Components
{
    public class CarBrain : BaseComponent
    {
        private TransformComponent Transform => Parent.Components.Get<TransformComponent>();
        private BoundingBoxComponent BoundingBox => Parent.Components.Get<BoundingBoxComponent>();
        private CarObject Parent => this.Owner as CarObject;

        public float _speed = 0.4500f;
        private bool _carStopped = false;

        private Timer _timer = new Timer();

        public CarBrain(GameObject owner) : base(owner)
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
                    Parent.State = CarStateEnum.NorthEast;
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {

                    TravelNorthWest(game);
                    Parent.State = CarStateEnum.NorthWest;
                }
                else
                {

                    TravelNorth(game);
                    Parent.State = CarStateEnum.Northbound;
                }
            }

            else if (inputService.GetKeyState(Keys.Down).State == ButtonState.States.Down)
            {
                if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
                {

                    TravelSouthEast(game);
                    Parent.State = CarStateEnum.SouthEast;
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {

                    TravelSouthWest(game);
                    Parent.State = CarStateEnum.SouthWest;
                }
                else
                {

                    TravelSouth(game);
                    Parent.State = CarStateEnum.Southbound;
                }
            }

            else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
            {
                TravelWest(game);
                Parent.State = CarStateEnum.Westbound;
            }

            else if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
            {
                TravelEast(game);
                Parent.State = CarStateEnum.Eastbound;
            }


            return new ValueTask();
        }

        protected void TravelEast(GameContext game)
        {
            Transform.Local.Position.X += _speed * game.GameTime.ElapsedMilliseconds;
        }

        protected void TravelWest(GameContext game)
        {
            Transform.Local.Position.X -= _speed * game.GameTime.ElapsedMilliseconds;
        }

        protected void TravelNorth(GameContext game)
        {
            Transform.Local.Position.Y -= _speed * game.GameTime.ElapsedMilliseconds;
        }

        protected void TravelSouth(GameContext game)
        {
            Transform.Local.Position.Y += _speed * game.GameTime.ElapsedMilliseconds;
        }

        protected void TravelNorthEast(GameContext game)
        {
            TravelNorth(game);
            TravelEast(game);
        }

        protected void TravelNorthWest(GameContext game)
        {
            TravelNorth(game);
            TravelWest(game);
        }

        protected void TravelSouthEast(GameContext game)
        {
            TravelSouth(game);
            TravelEast(game);
        }

        protected void TravelSouthWest(GameContext game)
        {
            TravelSouth(game);
            TravelWest(game);
        }

    }
}