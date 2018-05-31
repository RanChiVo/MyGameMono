using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGameMono.Managerments;
using MyGameMono.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameMono.Sprites
{
    public class Sprite
    {
        #region Fields

        public AnimationManagerments _animationManager;

        public Dictionary<string, Animation> _animation;

        public Vector2 _position;

        public Rectangle  _rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height); 
            }
        }
        protected Texture2D _texture;


        bool jumping= false;
        float StarY = 540 ;
        float jumpspeed;
        #endregion

        #region Properties

        public Input Input;

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (_animationManager != null)
                {
                    _animationManager.Position = _position;
                }
            }
        }

        public float Speed = 1f;

        public Vector2 Velocity;
        #endregion


        #region Method 

        public virtual void Draw(SpriteBatch spriteBatch)
        {
           

            if (_texture != null)
            {
                spriteBatch.Draw(_texture, Position, Color.White);
            }
            else if (_animationManager != null)
            {
                _animationManager.Draw(spriteBatch);
            }

            else throw new Exception("This ain't right!...");
           
        }


        public virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                Velocity.Y = -Speed;

            }

            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                Velocity.Y = Speed;
            }

            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X = Speed;
            }

            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X = Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Jump))
            {

                jumping = true;
                jumpspeed = -20;
              
            }
           
        }

        protected virtual void SetAnimation()
        {
          

            if (Velocity.X > 0)
            {
                _animationManager.Play(_animation["WalkRight"]);
           

            }


            else if (Velocity.X < 0)
            {
                _animationManager.Play(_animation["WalkLeft"]);
                
            }



            else if (Velocity.Y > 0)
            {
                _animationManager.Play(_animation["Jump"]);
               
            }
            else if (jumping)
            {
                _position.Y += jumpspeed;
                jumpspeed += 1;
                if (_position.Y >= StarY)
                {
                    _position.Y = StarY;
                    jumping = false;


                }



            }


        }

        public Sprite(Dictionary<string, Animation> animations)
        {
            _animation = animations;
            _animationManager = new AnimationManagerments(_animation.First().Value);
            

        }

        public Sprite(Texture2D texture, Rectangle rectangle)
        {
            _texture = texture;
            _position.Y = StarY;

        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();
            SetAnimation();
            _animationManager.Update(gameTime);
            Position += Velocity;
            Velocity = Vector2.Zero;
          
        }

        public bool IsTouchingLeft(Rectangle rectangle)
        {
            return this._rectangle.Right + this.Velocity.X > rectangle.Left &&
                   this._rectangle.Left < rectangle.Left &&
                   this._rectangle.Bottom > rectangle.Top &&
                   this._rectangle.Top < rectangle.Bottom;
        }


        public bool IsTouchingRight(Rectangle rectangle)
        {
            return this._rectangle.Left + this.Velocity.X < rectangle.Right &&
                   this._rectangle.Right > rectangle.Right &&
                   this._rectangle.Bottom > rectangle.Top &&
                   this._rectangle.Top < rectangle.Bottom;
        }


        public bool IsTouchingTop(Rectangle rectangle)
        {
            return this._rectangle.Bottom  + this.Velocity.Y > rectangle.Top &&
                   this._rectangle.Top < rectangle.Top &&
                   this._rectangle.Right > rectangle.Left &&
                   this._rectangle.Left < rectangle.Right;
        }

        public bool IsTouchingBottom(Rectangle rectangle)
        {
            return this._rectangle.Top + this.Velocity.Y < rectangle.Bottom &&
                   this._rectangle.Bottom > rectangle.Bottom &&
                   this._rectangle.Right > rectangle.Left &&
                   this._rectangle.Left < rectangle.Right;
        }
        #endregion
    }
}
