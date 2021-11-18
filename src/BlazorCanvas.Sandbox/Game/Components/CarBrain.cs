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
            if (!Parent.Stopped)
            {

                if (Parent.State == CarStateEnum.Northbound)
                {
                    TravelNorth(game);
                }
                if (Parent.State == CarStateEnum.Eastbound)
                {

                    TravelEast(game);
                }
                if (Parent.State == CarStateEnum.Southbound)
                {

                    TravelSouth(game);
                }
                if (Parent.State == CarStateEnum.Westbound)
                {

                    TravelWest(game);
                }
                if (Parent.State == CarStateEnum.NorthEast)
                {

                    TravelNorthEast(game);
                }
                if (Parent.State == CarStateEnum.NorthWest)
                {

                    TravelNorthWest(game);
                }
                if (Parent.State == CarStateEnum.SouthEast)
                {

                    TravelSouthEast(game);
                }
                if (Parent.State == CarStateEnum.SouthWest)
                {

                    TravelSouthWest(game);
                }

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