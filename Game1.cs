using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyGameMono.Models;
using MyGameMono.Sprites;
using System.Collections.Generic;

namespace MyGameMono
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private List<Sprite> _sprites;
        Scrolling scrolling1;
        Scrolling scrolling2;
        Scrolling Ostacles1;
        Scrolling Ostacles2;
        Scrolling Ostacles3;
        Scrolling Ostacles4;

        int speed=10;

        int score = 0;

        bool IsTouch = false;

      



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        protected void CheckCollision(List<Sprite> _sprite, Rectangle _rectangle)
        {
            Rectangle rectangle;
            foreach (Sprite sprite in _sprite)
            {
                rectangle = new Rectangle((int)sprite._position.X, (int)sprite._position.Y, 160, 189);
                if (rectangle.Intersects(_rectangle))
                {
                    IsTouch = true;
                }
            }

           // IsTouch = true;
            //foreach (var sprite in _sprite)
            //{
                //if (sprite.IsTouchingLeft(_rectangle))
                
                //if ((sprite.Velocity.X > 0 && sprite.IsTouchingLeft(_rectangle)) || (sprite.Velocity.X < 0 && sprite.IsTouchingRight(_rectangle)))

                //{
                //    sprite.Velocity.X = 0;
                //    IsTouch = true;

                //}

                //if ((sprite.Velocity.Y > 0 && sprite.IsTouchingTop(_rectangle)) || (sprite.Velocity.Y < 0 && sprite.IsTouchingBottom(_rectangle)))

                //{
                //    sprite.Velocity.Y = 0;
                //    IsTouch = true;
                //}

                //sprite.Position += sprite.Velocity;

                //sprite.Velocity = Vector2.Zero;

              //}
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            scrolling1 = new Scrolling(Content.Load<Texture2D>("Background/Background1"), new Rectangle(0, 0, 1000, 800));

            scrolling2 = new Scrolling(Content.Load<Texture2D>("Background/Background1"), new Rectangle(1000, 0, 1000, 800));


            Ostacles1 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle1"), new Rectangle(800, 540, 100, 100));
            Ostacles2 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle2"), new Rectangle(100, 70, 100, 100));
            Ostacles3 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle3"), new Rectangle(900, 540, 200, 200));
            Ostacles4 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle4"), new Rectangle(600, 540, 200, 200));



            var animations = new Dictionary<string, Animation>()

            {
                {"WalkRight", new Animation(Content.Load<Texture2D>("Character/WalkingRight"), 6) },
                 {"WalkLeft", new Animation(Content.Load<Texture2D>("Character/WalkingLeft"), 6) },
                  {"Jump", new Animation(Content.Load<Texture2D>("Character/Jumping"), 5) },

            };

            _sprites = new List<Sprite>()
            {
                new Sprite(animations)
                {
                    Position  = new Vector2(100,540),
                    Input = new Input()
                    {
                        Right = Keys.Right,
                        Left = Keys.Left,
                        Jump = Keys.Space,
                        

                    },
                },

            //    new Sprite(new Dictionary<string, Animation>()
            //{
            //    {"Obstacle", new Animation(Content.Load<Texture2D>("Obstacle/Obstacle2"), 3) },
               

            //})
            //    {
            //        Position  = new Vector2(400,100),
            //        Input = new Input()
            //        {
            //            Right = Keys.Right,
            //            Left = Keys.Left,
            //            Jump = Keys.Space,


            //        },
            //    },
            };

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            score++;
            scrolling1.Update(speed);
            scrolling2.Update(speed);

        

            if (scrolling1.rectangle.X + scrolling1.texture.Width <= 0)
            {
                scrolling1.rectangle.X = scrolling2.rectangle.X + scrolling2.texture.Width;
            }


            if (scrolling2.rectangle.X + scrolling2.texture.Width <= 0)
            {
                scrolling2.rectangle.X = scrolling1.rectangle.X + scrolling1.texture.Width;

            }


            if (Ostacles1.rectangle.X + Ostacles1.texture.Width <= 0)
            {
                Ostacles1.rectangle.X = Ostacles2.rectangle.X + graphics.PreferredBackBufferWidth * 3;
            }


            if (Ostacles2.rectangle.X + graphics.PreferredBackBufferWidth * 3 <= 0)
            {
                Ostacles2.rectangle.X = Ostacles1.rectangle.X + graphics.PreferredBackBufferWidth;

            }

            if (Ostacles3.rectangle.X + Ostacles4.texture.Width <= 0)
            {
                Ostacles3.rectangle.X = Ostacles4.rectangle.X + graphics.PreferredBackBufferWidth;
            }


            if (Ostacles3.rectangle.X + graphics.PreferredBackBufferWidth * 2 <= 0)
            {
                Ostacles4.rectangle.X = Ostacles3.rectangle.X + Ostacles3.texture.Width;

            }
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);


            }
            CheckCollision(_sprites, Ostacles1.rectangle);

            CheckCollision(_sprites, Ostacles2.rectangle);


            CheckCollision(_sprites, Ostacles3.rectangle);


            CheckCollision(_sprites, Ostacles4.rectangle);


            if (IsTouch == true)
            {
                speed = 0;
            }

            Ostacles3.Update(speed);
            Ostacles4.Update(speed);


            Ostacles1.Update(speed);
            Ostacles2.Update(speed);


            
              
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            scrolling1.Draw(spriteBatch);
            scrolling2.Draw(spriteBatch);
            

            //spriteBatch.DrawString(font,score.ToString(), new Vector2(10, 10), Color.Black);
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);
               
            }


            Ostacles1.Draw(spriteBatch);

            Ostacles2.Draw(spriteBatch);

            Ostacles3.Draw(spriteBatch);


            Ostacles4.Draw(spriteBatch);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
