using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Components
{
    public class BaseMoveComponent : BaseComponent
    {
        private TransformComponent Transform => Parent.Components.Get<TransformComponent>();
        private BoundingBoxComponent BoundingBox => Parent.Components.Get<BoundingBoxComponent>();
        private CarObject Parent => this.Owner as CarObject;

        public float _speed = 0.4500f;


        public BaseMoveComponent(GameObject owner) : base(owner)
        {
            BoundingBox.OnCollision += (sender, collidedWith) =>
            {
                // check if we're colliding with another car
                if (!collidedWith.Owner.Components.TryGet<BaseMoveComponent>(out var _))
                    this.Owner.Enabled = false;
            };
        }


        public override ValueTask Update(GameContext game)
        {
            if (Parent.State != CarState.Stopped)
            {

                if (Parent.State == CarState.Northbound)
                {
                    TravelNorth(game);
                }
                if (Parent.State == CarState.Eastbound)
                {

                    TravelEast(game);
                }
                if (Parent.State == CarState.Southbound)
                {

                    TravelSouth(game);
                }
                if (Parent.State == CarState.Westbound)
                {

                    TravelWest(game);
                }
                if (Parent.State == CarState.NorthEast)
                {

                    TravelNorthEast(game);
                }
                if (Parent.State == CarState.NorthWest)
                {

                    TravelNorthWest(game);
                }
                if (Parent.State == CarState.SouthEast)
                {

                    TravelSouthEast(game);
                }
                if (Parent.State == CarState.SouthWest)
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