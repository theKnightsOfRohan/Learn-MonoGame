using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LearnMonoGame
{
    public class MyObj
    {
        private Texture2D texture;
        private Vector2 position;

        public MyObj(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            // Update logic here
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
