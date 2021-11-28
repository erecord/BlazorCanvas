using System.Drawing;
using System.Threading.Tasks;
using Blazor.Extensions;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Assets;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Example11.Game.Components;
using BlazorCanvas.Core.Utils;
using BlazorCanvas.Sandbox.Game.GameObjects;
using BlazorCanvas.Sandbox.Game.Builders;
using System.Numerics;

namespace BlazorCanvas.Sandbox.Game
{
    public class SandboxGame : GameContext
    {
        private readonly BECanvasComponent _canvas;
        private readonly SandboxGameFacade _sandboxGameFacade;

        public SandboxGame(BECanvasComponent canvas, SandboxGameFacade sandboxGameFacade)
        {
            _canvas = canvas;
            _sandboxGameFacade = sandboxGameFacade;
        }

        protected override async ValueTask Init()
        {
            this.AddService(_sandboxGameFacade.InputService);
            this.AddService(_sandboxGameFacade.AssetResolver);

            var collisionService = new CollisionService(this, new Size(64, 64));
            this.AddService(collisionService);

            var sceneGraph = new SceneGraph(this);
            this.AddService(sceneGraph);

            BuildAndAddCar(sceneGraph, _sandboxGameFacade.PathFollowerCarObjectBuilder);
            BuildAndAddCar(sceneGraph, _sandboxGameFacade.UserControlledCarObjectBuilder).SetPosition(new Vector2(800, 600));

            var context = await _canvas.CreateCanvas2DAsync();
            var renderService = new RenderService(this, context);
            this.AddService(renderService);
        }

        private GameObject BuildPlayer()
        {
            var player = new GameObject();

            var spriteSheet = _sandboxGameFacade.AssetResolver.Get<SpriteSheet>("assets/sheet.json");
            var sprite = spriteSheet.Get("playerShip2_green.png");

            var playerTransform = player.Components.Add<TransformComponent>();

            playerTransform.Local.Position.X = _canvas.Width / 2;
            playerTransform.Local.Position.Y = _canvas.Height / 2;

            var playerSpriteRenderer = player.Components.Add<SpriteRenderComponent>();
            playerSpriteRenderer.Sprite = sprite;

            var bbox = player.Components.Add<BoundingBoxComponent>();
            bbox.SetSize(sprite.Bounds.Size);

            var rigidBody = player.Components.Add<MovingBody>();
            rigidBody.MaxSpeed = 400f;

            player.Components.Add<PlayerBrain>();

            return player;
        }


        private CarObject BuildAndAddCar(SceneGraph sceneGraph, BaseCarObjectBuilder carBuilder)
        {
            var car = carBuilder.Build();
            sceneGraph.Root.AddChild(car);
            return car;
        }

        private TrafficLightObject BuildAndAddTrafficLight(SceneGraph sceneGraph)
        {
            var trafficLight = new TrafficLightObject();
            sceneGraph.Root.AddChild(trafficLight);
            return trafficLight;
        }

        private void AddAsteroid(SceneGraph sceneGraph)
        {
            var asteroid = new GameObject();

            var spriteSheet = _sandboxGameFacade.AssetResolver.Get<SpriteSheet>("assets/sheet.json");
            var sprite = spriteSheet.Get("meteorBrown_big1.png");

            var transform = asteroid.Components.Add<TransformComponent>();

            var w = (double)_canvas.Width;
            var rx = MathUtils.Random.NextDouble(0, .35, .65, 1);
            var tx = MathUtils.Normalize(rx, 0, 1, -1, 1);
            transform.Local.Position.X = (float)(tx * w / 2 + w / 2);

            var h = (double)_canvas.Height;
            var ry = MathUtils.Random.NextDouble(0, .35, .65, 1);
            var ty = MathUtils.Normalize(ry, 0, 1, -1, 1);
            transform.Local.Position.Y = (float)(ty * h / 2 + h / 2);

            var spriteRenderer = asteroid.Components.Add<SpriteRenderComponent>();
            spriteRenderer.Sprite = sprite;

            var bbox = asteroid.Components.Add<BoundingBoxComponent>();
            bbox.SetSize(sprite.Bounds.Size);

            asteroid.Components.Add<AsteroidBrain>();

            sceneGraph.Root.AddChild(asteroid);
        }

    }
}