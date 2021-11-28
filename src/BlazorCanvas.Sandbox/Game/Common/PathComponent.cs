using System;
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
        private CarObject CarObject => (Owner as CarObject);
        public PathComponent(GameObject owner) : base(owner)
        {
        }

        public List<Vector2> PathPoints { get; private set; } = new List<Vector2>();

        public override void OnStart(GameContext game)
        {
            base.OnStart(game);

            var inputService = game.GetService<InputService>();
            inputService.MouseLeftClick += onMouseDown;
        }

        private void onMouseDown(object sender, Vector2 mousePosition)
        {
            PathPoints.Add(mousePosition);
            Console.WriteLine($"Path point added: {mousePosition}");
        }

        public override ValueTask Update(GameContext game)
        {
            if (PathPoints.Count > 0)
            {
                var nextPathPoint = PathPoints[0];

                if (CarObject.TargetPositionCallback == null)
                {
                    CarObject.TargetPositionCallback = () => nextPathPoint;
                }
                else if (isWithinDistance(CarObject.Position, nextPathPoint, 100))
                {
                    Console.WriteLine($"Path point reached: {nextPathPoint}");
                    PathPoints.RemoveAt(0);
                    CarObject.TargetPositionCallback = null;
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
                CarObject.State = CarState.Stopped;
            }

            return base.Update(game);
        }

    }
}