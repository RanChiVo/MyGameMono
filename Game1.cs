using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MyGameMono.Models;
using MyGameMono.Sprites;
using System;
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
        private List<Sprite> _sprites, BatSprite;

        Scrolling scrolling1;
        Scrolling scrolling2;
        Scrolling Ostacles1;
        Scrolling Ostacles2;
        Scrolling Ostacles3;
        Scrolling Ostacles4;
        Scrolling Ostacles5;

        Song song;
        // SoundEffect song2;
        Song song2;

        Bat Bat;

        int speed = 10;

        int score = 0;

        private float _timer;

        bool IsTouch = false;

        int d = 0;

        // SoundEffect _soundEffect;

        Song _soundEffect;

        SpriteFont font;

        Vector2 position_Score = new Vector2(50, 100);

        Vector2 positionName = new Vector2(50, 80);

        bool IsObstancle = false;

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
                    MediaPlayer.Play(song2);
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

            scrolling1 = new Scrolling(Content.Load<Texture2D>("Background/background1"), new Rectangle(0, 0, 1000, 800));
            scrolling2 = new Scrolling(Content.Load<Texture2D>("Background/background2"), new Rectangle(1000, 0, 1000, 800));

            Ostacles1 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle1"), new Rectangle(800, 540, 150, 130));
            Ostacles2 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle2"), new Rectangle(100, 5, 150, 130));
            Ostacles3 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle3"), new Rectangle(900, 540, 200, 200));
            Ostacles4 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle4"), new Rectangle(600, 540, 200, 200));
            Ostacles5 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle5"), new Rectangle(400, 600, 200, 200));

            Bat = new Bat(Content.Load<Texture2D>("Obstacle/head"), new Rectangle(900, 100, 150, 150));

            font = Content.Load<SpriteFont>("font");

            _soundEffect = Content.Load<Song>("jumpmusic");
            song2 = Content.Load<Song>("_Touch");
            song = Content.Load<Song>("Song");

            MediaPlayer.Play(song);

            var animationBat = new Dictionary<string, Animation>()
            {
                {"WalkLeft", new Animation(Content.Load<Texture2D>("Obstacle/walkletf"), 3) },
                 //{"WalkLeft", new Animation(Content.Load<Texture2D>("Obstacle/FlyRight"), 6) },
                 // {"Jump", new Animation(Content.Load<Texture2D>("Obstacle/Jump"), 6) },

            };

            BatSprite = new List<Sprite>()
            {
                new Sprite(animationBat)
                {
                   Position = new Vector2(100, 540),
                    Input = new Input()
                    {
                        Right = Keys.Right,
                        Left = Keys.Left,
                        Jump = Keys.Space,
                    },
                },

            };

            //var animationBat = new Dictionary<string, Animation>()
            //{
            //   {"WalkRight", new Animation(Content.Load<Texture2D>("Obstacle/walkright"), 3) },
            //     {"WalkLeft", new Animation(Content.Load<Texture2D>("Obstacle/walkletf"), 3) },


            //};

            //BatSprite = new List<Sprite>()
            //{
            //    new Sprite(animationBat)
            //    {
            //     Position = new Vector2(400, 540),
            //        Input = new Input()
            //        {
            //            IsObstacle = true,


            //        },
            //    },

            //};
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
                 Position = new Vector2(100, 540),
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

            if (score % 10 == 0 && score > 0)
            {

                Bat._rectangle.X -= Convert.ToInt32(1000 * 15 / 1000f);
            }

            if (score % 7 == 0 && score > 0)
            {
                Ostacles5.rectangle.Y -= Convert.ToInt32(1000 * 15 / 1000f);
             //     Ostacles5.rectangle.Width += Convert.ToInt32(1000 * 19 / 100f);
            }

              
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            scrolling1.Update(speed);
            scrolling2.Update(speed);

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            score = Convert.ToInt32(_timer);



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
                sprite.Update(gameTime, _sprites, _soundEffect, IsObstancle);

            }

            foreach (var bat in BatSprite)
            {
                bat.Update(gameTime, BatSprite, _soundEffect, IsObstancle);

            }
            CheckCollision(_sprites, Ostacles1.rectangle);

            CheckCollision(_sprites, Ostacles2.rectangle);

            CheckCollision(_sprites, Ostacles3.rectangle);

            CheckCollision(_sprites, Ostacles4.rectangle);


            if (IsTouch == true)
            {
                speed = 0;
                //   song2.Play();
                MediaPlayer.Play(song);
                //      MediaPlayer.Stop();
                score = Convert.ToInt32(_timer);
                _timer = score;

            }

            Ostacles3.Update(speed);
            Ostacles4.Update(speed);

            Ostacles1.Update(speed);
            Ostacles2.Update(speed);

         

            if (speed == 0 && Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                this.LoadContent();
                speed = 10;
                IsTouch = false;
                _timer = 0;
                d = 0;
            }

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

            scrolling1.Draw(spriteBatch);//Draw background
            scrolling2.Draw(spriteBatch);

            //spriteBatch.DrawString(font,score.ToString(), new Vector2(10, 10), Color.Black);
            foreach (var sprite in _sprites)
            {
                sprite.Draw(spriteBatch);

            }

            Ostacles1.Draw(spriteBatch);//Draw Obstacle1

            Ostacles2.Draw(spriteBatch);//Draw Obstacle2

            Ostacles3.Draw(spriteBatch);//Draw Obstacle3

            Ostacles4.Draw(spriteBatch);//Draw Obstacle3

            spriteBatch.DrawString(font, "Score:" + score.ToString(), position_Score, Color.Violet);//Show score
            spriteBatch.DrawString(font, "THE BRAVE GIRL ", positionName, Color.Violet);

            if (score % 10 == 0 && score > 0)
            {
                Bat.Draw(spriteBatch);
            }

            if (score % 7 == 0 && score > 0)
            {
                Ostacles5.Draw(spriteBatch);
            }

            // if (score > 10 )
            // {
            ////     IsObstancle = true;

            //     foreach (var batSprite in BatSprite)
            //     {
            //         batSprite.Draw(spriteBatch);

            //     }
            // }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}