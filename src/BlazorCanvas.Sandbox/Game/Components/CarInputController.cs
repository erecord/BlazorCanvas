using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Sandbox.Core;

namespace BlazorCanvas.Example11.Game.Components
{
    public class CarInputController : BaseComponent
    {
        private CarObject Parent => this.Owner as CarObject;

        public CarInputController(GameObject owner) : base(owner)
        {
        }

        public override ValueTask Update(GameContext game)
        {
            var inputService = game.GetService<InputService>();

            Parent.Stopped = true;

            if (inputService.GetKeyState(Keys.Up).State == ButtonState.States.Down)
            {
                if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
                {
                    Parent.State = CarStateEnum.NorthEast;
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {
                    Parent.State = CarStateEnum.NorthWest;
                }
                else
                {
                    Parent.State = CarStateEnum.Northbound;
                }

                Parent.Stopped = false;
            }

            else if (inputService.GetKeyState(Keys.Down).State == ButtonState.States.Down)
            {
                if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
                {

                    Parent.State = CarStateEnum.SouthEast;
                }
                else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
                {

                    Parent.State = CarStateEnum.SouthWest;
                }
                else
                {

                    Parent.State = CarStateEnum.Southbound;
                }
                Parent.Stopped = false;
            }

            else if (inputService.GetKeyState(Keys.Left).State == ButtonState.States.Down)
            {
                Parent.State = CarStateEnum.Westbound;
                Parent.Stopped = false;
            }

            else if (inputService.GetKeyState(Keys.Right).State == ButtonState.States.Down)
            {
                Parent.State = CarStateEnum.Eastbound;
                Parent.Stopped = false;
            }

            return new ValueTask();
        }

    }
}