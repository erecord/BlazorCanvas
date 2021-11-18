using System.Threading.Tasks;
using BlazorCanvas.Core;
using BlazorCanvas.Sandbox.Core;

namespace BlazorCanvas.Example11.Game.Components
{

    public class CarBrainAutomatic : CarBrain
    {

        private CarObject Parent => Owner as CarObject;

        public CarBrainAutomatic(GameObject owner) : base(owner)
        {
            _speed = 0.1500f;
        }

        public override ValueTask Update(GameContext game)
        {
            if (Parent.State == CarStateEnum.Northbound)
            {
                TravelNorth(game);
            }
            if (Parent.State == CarStateEnum.Eastbound)
            {

                TravelEast(game);
            }
            if (Parent.State == CarStateEnum.Southbound)
            {

                TravelSouth(game);
            }
            if (Parent.State == CarStateEnum.Westbound)
            {

                TravelWest(game);
            }
            if (Parent.State == CarStateEnum.NorthEast)
            {

                TravelNorthEast(game);
            }
            if (Parent.State == CarStateEnum.NorthWest)
            {

                TravelNorthWest(game);
            }
            if (Parent.State == CarStateEnum.SouthEast)
            {

                TravelSouthEast(game);
            }
            if (Parent.State == CarStateEnum.SouthWest)
            {

                TravelSouthWest(game);
            }

            return new ValueTask();
        }
    }
}