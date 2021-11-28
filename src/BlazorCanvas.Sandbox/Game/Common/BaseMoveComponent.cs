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
        private MoveableGameObject Parent => this.Owner as MoveableGameObject;

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
            if (Parent.CurrentDirection != DirectionState.Stopped)
            {

                if (Parent.CurrentDirection == DirectionState.Northbound)
                {
                    TravelNorth(game);
                }
                if (Parent.CurrentDirection == DirectionState.Eastbound)
                {

                    TravelEast(game);
                }
                if (Parent.CurrentDirection == DirectionState.Southbound)
                {

                    TravelSouth(game);
                }
                if (Parent.CurrentDirection == DirectionState.Westbound)
                {

                    TravelWest(game);
                }
                if (Parent.CurrentDirection == DirectionState.NorthEast)
                {

                    TravelNorthEast(game);
                }
                if (Parent.CurrentDirection == DirectionState.NorthWest)
                {

                    TravelNorthWest(game);
                }
                if (Parent.CurrentDirection == DirectionState.SouthEast)
                {

                    TravelSouthEast(game);
                }
                if (Parent.CurrentDirection == DirectionState.SouthWest)
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