using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Sandbox.Core;

namespace BlazorCanvas.Example11.Game.Components
{

    public class CarBrainAutomatic : CarBrain
    {

        public CarStateEnum CarState { get; set; }
        public CarBrainAutomatic(GameObject owner) : base(owner)
        {
            _speed = 0.3000f;
        }

        public override ValueTask Update(GameContext game)
        {
            if (CarState == CarStateEnum.Northbound)
            {

                TravelNorth(game);
            }
            if (CarState == CarStateEnum.Eastbound)
            {

                TravelEast(game);
            }
            if (CarState == CarStateEnum.Westbound)
            {

                TravelWest(game);
            }
            if (CarState == CarStateEnum.NorthWest)
            {

                TravelNorthWest(game);
            }

            return new ValueTask();
        }
    }
}