﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGameMono.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMono.Managerments
{
    public class AnimationManagerments
    {
        private Animation _animation;

        public Rectangle _rectangle;

        private float _timer;

        public Vector2 Position { get; set; }
       

        private int _score;

        public int Score { get => _score; set => _score = value; }

        public AnimationManagerments(Animation animation)
        {
            _animation = animation;
        }

        public void Draw(SpriteBatch  spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture, Position, new Rectangle(_animation.CurrentFrame * _animation.FrameWidth, 0,
                                                                _animation.FrameWidth, _animation.FrameHeight), Color.White);

        }
        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;
            _animation = animation;

            _animation.CurrentFrame = 0;

            _timer = 0;
        }

        public void Stop()
        {
            _timer = 0f;
            Score =Convert.ToInt32( _timer);
            _animation.CurrentFrame = 0;
        }


        public void Update (GameTime gameTime)
        {
            _rectangle = new Rectangle(_animation.CurrentFrame * _animation.FrameWidth, 0,
                                                                _animation.FrameWidth, _animation.FrameHeight);

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            _score = Convert.ToInt32(_timer);

            if(_timer > _animation.FrameSpeed)
            {
                _timer = 0f;
                _animation.CurrentFrame++;
                
                if(_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }
        }
    }
}
