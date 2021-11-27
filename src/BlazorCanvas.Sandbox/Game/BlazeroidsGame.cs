using System.Drawing;
using System.Threading.Tasks;
using Blazor.Extensions;
using BlazorCanvas.Core;
using BlazorCanvas.Core.Assets;
using BlazorCanvas.Core.Components;
using BlazorCanvas.Example11.Game.Components;
using BlazorCanvas.Core.Utils;
using BlazorCanvas.Sandbox.GameObjects;
using System.Numerics;

namespace BlazorCanvas.Example11.Game
{
    public class BlazeroidsGame : GameContext
    {
        private readonly BECanvasComponent _canvas;
        private readonly IAssetsResolver _assetsResolver;

        public BlazeroidsGame(BECanvasComponent canvas, IAssetsResolver assetsResolver)
        {
            _canvas = canvas;
            _assetsResolver = assetsResolver;
        }

        protected override async ValueTask Init()
        {
            this.AddService(new InputService());
            this.AddService(_assetsResolver);

            var collisionService = new CollisionService(this, new Size(64, 64));
            this.AddService(collisionService);

            var sceneGraph = new SceneGraph(this);
            this.AddService(sceneGraph);

            // var player = BuildPlayer();
            // sceneGraph.Root.AddChild(player);

            // for (var i = 0; i != 6; ++i)
            // AddAsteroid(sceneGraph);
            var car1 = CarFactory.CreateUserControlledCar(new UserControlledCarObjectBuilder());
            var car2 = new SystemControlledCarObjectBuilder()
                        .SetPosition(new Vector2(_canvas.Width - 200, _canvas.Height - 200))
                        .Build();
            car2.SetGetTargetPositionCallback(() => car1.Position);

            sceneGraph.Root.AddChild(car1);
            sceneGraph.Root.AddChild(car2);

            // var trafficLight = BuildAndAddTrafficLight(sceneGraph);
            // var trafficLight2 = BuildAndAddTrafficLight(sceneGraph);

            // await Task.Delay(1000);
            // trafficLight.TrafficLightState = TrafficLightState.Green;
            // await Task.Delay(3000);
            // trafficLight2.TrafficLightState = TrafficLightState.Green;

            var context = await _canvas.CreateCanvas2DAsync();
            var renderService = new RenderService(this, context);
            this.AddService(renderService);
        }


        private GameObject BuildPlayer()
        {
            var player = new GameObject();

            var spriteSheet = _assetsResolver.Get<SpriteSheet>("assets/sheet.json");
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


        // private CarObject BuildAndAddCar(SceneGraph sceneGraph)
        // {
        //     var car = CarFactory.CreateCar();
        //     sceneGraph.Root.AddChild(car);

        //     return car;
        //     // Task.Run(async () =>
        //     // {
        //     //     await Task.Delay(500);
        //     //     car2.State = CarStateEnum.NorthWest;
        //     //     await Task.Delay(1000);
        //     //     car2.State = CarStateEnum.Westbound;
        //     //     return Task.CompletedTask;
        //     // });
        // }

        private TrafficLightObject BuildAndAddTrafficLight(SceneGraph sceneGraph)
        {
            var trafficLight = new TrafficLightObject();
            sceneGraph.Root.AddChild(trafficLight);
            return trafficLight;
        }

        private void AddAsteroid(SceneGraph sceneGraph)
        {
            var asteroid = new GameObject();

            var spriteSheet = _assetsResolver.Get<SpriteSheet>("assets/sheet.json");
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