using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;
using BlazorCanvas.Sandbox.Game.GameObjects;

namespace BlazorCanvas.Sandbox.Game.Components
{
    public class CarUserControllerComponent : BaseComponent
    {
        private CarObject Parent => this.Owner as CarObject;

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
                    Parent.State = CarState.NorthEast;
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {
                    Parent.State = CarState.NorthWest;
                }
                else
                {
                    Parent.State = CarState.Northbound;
                }
            }

            else if (inputService.GetKeyState(Keys.Down).State == ButtonState.States.Down)
            {
                if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
                {

                    Parent.State = CarState.SouthEast;
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {

                    Parent.State = CarState.SouthWest;
                }
                else
                {

                    Parent.State = CarState.Southbound;
                }
            }

            else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
            {
                Parent.State = CarState.Westbound;
            }

            else if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
            {
                Parent.State = CarState.Eastbound;
            }

            return new ValueTask();
        }

    }
}