using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MGPerformance.Core
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _font;

        private readonly Point mapTileSize = new(30, 30);
        private readonly TextureActor[,] sprites;
        private readonly List<Texture2D> textures = [];
        private readonly Random random = new();
        public readonly int TileSize = 32;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            sprites = new TextureActor[mapTileSize.X, mapTileSize.Y];
        }

        protected override void Initialize()
        {
            base.Initialize();
            Components.Add(new FpsCounter(this, _font, Vector2.Zero));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Font");

            // Load textures
            for (int i = 0; i < 3; i++)
            {
                textures.Add(Content.Load<Texture2D>($"tile_{i + 1}"));
            }

            // Generate tilemap
            for (int y = 0; y < mapTileSize.Y; y++)
            {
                for (int x = 0; x < mapTileSize.X; x++)
                {
                    int r = random.Next(0, textures.Count);
                    sprites[x, y] = new TextureActor(textures[r], new Vector2(x * TileSize, y * TileSize), _spriteBatch);

                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            // Draw tilemap
            for (int y = 0; y < mapTileSize.Y; y++)
            {
                for (int x = 0; x < mapTileSize.X; x++)
                {
                    sprites[x, y].Draw();

                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
