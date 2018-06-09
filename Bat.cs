using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGameMono.Managerments;
using MyGameMono.Models;
using MyGameMono.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMono
{
    public class Bat
    {
        public Rectangle _rectangle;

        public Texture2D Texture;


        public Bat(Texture2D texture, Rectangle position)
        {
            _rectangle = position;
            Texture = texture;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, _rectangle , Color.White);
        }
        public void Update()
        {
            _rectangle.X = 400;
            _rectangle.Y = 600;
        }
    }
}
