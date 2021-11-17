using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Sandbox.Core;

namespace BlazorCanvas.Example11.Game.Components
{

    public class CarBrainAutomatic : CarBrain
    {

        public CarStates CarState { get; set; }
        public CarBrainAutomatic(GameObject owner) : base(owner)
        {
            _speed = 0.3000f;
        }

        public override ValueTask Update(GameContext game)
        {
            if (CarState == CarStates.Northbound)
            {

                TravelNorth(game);
            }
            if (CarState == CarStates.Eastbound)
            {

                TravelEast(game);
            }
            if (CarState == CarStates.Westbound)
            {

                TravelWest(game);
            }
            if (CarState == CarStates.NorthWest)
            {

                TravelNorthWest(game);
            }

            return new ValueTask();
        }
    }
}