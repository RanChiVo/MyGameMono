using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMono
{
    public class Background
    {
        public Texture2D texture;
        public Rectangle rectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
    class Scrolling : Background
    {
        public Scrolling(Texture2D newTexture, Rectangle newrectangle)
        {
            texture = newTexture;
            rectangle = newrectangle;
        }
        public void Update(int Speed)
        {
            rectangle.X -= Speed;
        }

    }
}
