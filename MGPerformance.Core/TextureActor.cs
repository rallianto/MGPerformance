using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MGPerformance.Core
{
    public class TextureActor
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public SpriteBatch SpriteBatch { get; set; }

        public TextureActor(Texture2D texture, Vector2 position, SpriteBatch spriteBatch) 
        {
            Texture = texture;
            Position = position;
            SpriteBatch = spriteBatch;
        }


        public void Draw()
        {
            SpriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }


    }
}
