using System.Threading.Tasks;
using BlazorCanvas.Example11.Core;

namespace BlazorCanvas.Example11.Game.Components
{

    public class CarBrainAutomatic : CarBrain
    {
        // TODO: Move CarStates into core library
        public enum CarStates
        {
            Northbound,
            Eastbound,
            Westbound,
            NorthWest
        }

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