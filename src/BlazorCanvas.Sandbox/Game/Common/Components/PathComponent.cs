using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Components
{
    public class PathComponent : BaseComponent
    {
        public List<Vector2> PathPoints { get; private set; } = new List<Vector2>();
        private MoveableGameObject _moveableGameObject => (Owner as MoveableGameObject);
        private TravelToTargetPositionComponent _travelToTargetPositionComponent => _moveableGameObject.Components.Get<TravelToTargetPositionComponent>();

        public PathComponent(GameObject owner) : base(owner)
        {
        }

        public override void OnStart(GameContext game)
        {
            var inputService = game.GetService<InputService>();
            inputService.MouseLeftClick += onMouseDown;

            base.OnStart(game);
        }

        private void onMouseDown(object sender, Vector2 mousePosition)
        {
            PathPoints.Add(mousePosition);
        }

        public override ValueTask Update(GameContext game)
        {
            if (PathPoints.Count > 0)
            {
                var nextPathPoint = PathPoints[0];


                if (_travelToTargetPositionComponent.TargetPosition == null)
                {
                    _travelToTargetPositionComponent.TargetPosition = nextPathPoint;
                }
                else if (isWithinDistance(_moveableGameObject.Position, nextPathPoint, 100))
                {
                    PathPoints.RemoveAt(0);
                    _travelToTargetPositionComponent.TargetPosition = null;
                }

                bool isWithinDistance(Vector2 pointOne, Vector2 pointTwo, int distanceTolerance)
                {
                    var distance = pointOne - pointTwo;
                    var distanceSquared = distance.LengthSquared();
                    var distanceToleranceSquared = distanceTolerance * distanceTolerance;
                    return distanceSquared < distanceToleranceSquared;
                };

            }
            else
            {
                _moveableGameObject.CurrentDirection = DirectionState.Stopped;
            }

            return base.Update(game);
        }

    }
}