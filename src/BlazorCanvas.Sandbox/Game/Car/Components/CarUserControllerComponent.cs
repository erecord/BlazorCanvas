using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Components
{
    public class CarUserControllerComponent : BaseComponent
    {
        private CarObject Car => this.Owner as CarObject;

        public CarUserControllerComponent(GameObject owner) : base(owner)
        {
        }

        public override ValueTask Update(GameContext game)
        {
            var inputService = game.GetService<InputService>();


            if (inputService.GetKeyState(Keys.Up).State == ButtonState.States.Down)
            {
                if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
                {
                    Car.CurrentDirection = DirectionState.NorthEast;
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {
                    Car.CurrentDirection = DirectionState.NorthWest;
                }
                else
                {
                    Car.CurrentDirection = DirectionState.Northbound;
                }
            }

            else if (inputService.GetKeyState(Keys.Down).State == ButtonState.States.Down)
            {
                if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
                {

                    Car.CurrentDirection = DirectionState.SouthEast;
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {

                    Car.CurrentDirection = DirectionState.SouthWest;
                }
                else
                {

                    Car.CurrentDirection = DirectionState.Southbound;
                }
            }

            else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
            {
                Car.CurrentDirection = DirectionState.Westbound;
            }

            else if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
            {
                Car.CurrentDirection = DirectionState.Eastbound;
            }
            else
            {
                Car.CurrentDirection = DirectionState.Stopped;
            }

            return new ValueTask();
        }

    }
}