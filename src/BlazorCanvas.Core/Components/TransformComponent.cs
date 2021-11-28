using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;
using BlazorCanvas.Core.Interfaces;
using BlazorCanvas.Core.Utils;

namespace BlazorCanvas.Core.Components
{
    public class TransformComponent : BaseComponent, ITransformComponent
    {
        private readonly Transform _local = Transform.Identity();
        private readonly Transform _world = Transform.Identity();

        private TransformComponent(GameObject owner) : base(owner)
        {
        }

        public override ValueTask Update(GameContext game)
        {
            _world.Clone(_local);

            if (null != Owner.Parent && Owner.Parent.Components.TryGet<TransformComponent>(out var parentTransform))
                _world.Position = _local.Position + parentTransform.World.Position;
            return new ValueTask();
        }

        public void SetRandomPosition(double canvasWidth, double canvasHeight)
        {
            var rx = MathUtils.Random.NextDouble(0, .35, .65, 1);
            var tx = MathUtils.Normalize(rx, 0, 1, -1, 1);
            Local.Position.X = (float)(tx * canvasWidth / 2 + canvasWidth / 2);

            var ry = MathUtils.Random.NextDouble(0, .35, .65, 1);
            var ty = MathUtils.Normalize(ry, 0, 1, -1, 1);
            Local.Position.Y = (float)(ty * canvasHeight / 2 + canvasHeight / 2);
        }

        public void SetPosition(Vector2 position)
        {
            Local.Position = position;
        }

        public Transform Local => _local;
        public Transform World => _world;
    }
}