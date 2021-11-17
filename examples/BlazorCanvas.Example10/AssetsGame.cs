using System;
using System.Threading.Tasks;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using BlazorCanvas.Example10.Core;
using BlazorCanvas.Example10.Core.Assets;
using BlazorCanvas.Example10.Core.Components;

namespace BlazorCanvas.Example10
{
    public class AssetsGame : GameContext
    {
        private readonly Canvas2DContext _context;
        private readonly SceneGraph _sceneGraph;
        private readonly IAssetsResolver _assetsResolver;

        private AssetsGame(Canvas2DContext context, IAssetsResolver assetsResolver)
        {
            _context = context;
            _assetsResolver = assetsResolver;
            _sceneGraph = new SceneGraph();
        }

        public static async ValueTask<AssetsGame> Create(BECanvasComponent canvas, IAssetsResolver assetsResolver)
        {
            var context = await canvas.CreateCanvas2DAsync();
            var game = new AssetsGame(context, assetsResolver);

            var fpsCounter = new GameObject();
            fpsCounter.Components.Add<FPSCounterComponent>();
            game._sceneGraph.Root.AddChild(fpsCounter);

            var player = new GameObject();
            var playerSprite = assetsResolver.Get<Sprite>("assets/playerShip2_green.png");
            var playerTransform = player.Components.Add<TransformComponent>();
            playerTransform.Local.Position.X = canvas.Width / 2 - playerSprite.Size.Width;
            playerTransform.Local.Position.Y = canvas.Height - playerSprite.Size.Height * 2;
            var playerSpriteRenderer = player.Components.Add<SpriteRenderComponent>();
            playerSpriteRenderer.Sprite = playerSprite;
            game._sceneGraph.Root.AddChild(player);

            var enemy = new GameObject();
            var enemySprite = assetsResolver.Get<Sprite>("assets/enemyRed1.png");
            var enemyTransform = enemy.Components.Add<TransformComponent>();
            enemyTransform.Local.Position.X = canvas.Width / 2 - enemySprite.Size.Width;
            enemyTransform.Local.Position.Y = enemySprite.Size.Height * 2;
            var enemySpriteRenderer = enemy.Components.Add<SpriteRenderComponent>();
            enemySpriteRenderer.Sprite = enemySprite;
            game._sceneGraph.Root.AddChild(enemy);

            var rand = new Random();
            for (var i = 0; i != 6; ++i)
                AddAsteroid(game, canvas, assetsResolver, rand);

            return game;
        }

        private static void AddAsteroid(AssetsGame game, BECanvasComponent canvas, IAssetsResolver assetsResolver, Random rand)
        {
            var asteroid = new GameObject();

            var sprite = assetsResolver.Get<Sprite>("assets/meteorBrown_big1.png");
            
            var transform = asteroid.Components.Add<TransformComponent>();
            transform.Local.Position.X = rand.Next(sprite.Size.Width * 2, (int) canvas.Width - sprite.Size.Width * 2);
            transform.Local.Position.Y = rand.Next(sprite.Size.Height * 2, (int)(canvas.Height/4)*3);

            var spriteRenderer = asteroid.Components.Add<SpriteRenderComponent>();
            spriteRenderer.Sprite = sprite;

            asteroid.Components.Add<AsteroidBrainComponent>();

            game._sceneGraph.Root.AddChild(asteroid);
        }

        protected override async ValueTask Update()
        {
            await _sceneGraph.Update(this);
        }

        protected override async ValueTask Render()
        {
            await _context.ClearRectAsync(0, 0, this.Display.Size.Width, this.Display.Size.Height);
            
            await Render(_sceneGraph.Root);
        }

        private async ValueTask Render(GameObject node)
        {
            if (null == node)
                return;

            foreach(var component in node.Components)
                if (component is IRenderable renderable)
                    await renderable.Render(this, _context);

            foreach (var child in node.Children)
                await Render(child);
        }
    }
}