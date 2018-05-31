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
        List<Rectangle> ListRectangle;
        private List<Sprite> _sprites;
        Scrolling scrolling1;
        Scrolling scrolling2;
        Scrolling Ostacles1;
        Scrolling Ostacles2;
        Scrolling Ostacles3;
        Scrolling Ostacles4;


        



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
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            scrolling1 = new Scrolling(Content.Load<Texture2D>("Background/Background1"), new Rectangle(0, 0, 1000, 800));
            ListRectangle.Add(scrolling1.rectangle);

            scrolling2 = new Scrolling(Content.Load<Texture2D>("Background/Background1"), new Rectangle(1000, 0, 1000, 800));
            ListRectangle.Add(scrolling2.rectangle);

            Ostacles1 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle1"), new Rectangle(100, 540, 100, 100));
            ListRectangle.Add(Ostacles1.rectangle);

            Ostacles2 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle2"), new Rectangle(700, 540, 100, 100));
            ListRectangle.Add(Ostacles2.rectangle);

            Ostacles3 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle3"), new Rectangle(400, 540, 200, 200));
            ListRectangle.Add(Ostacles3.rectangle);


            Ostacles4 = new Scrolling(Content.Load<Texture2D>("Obstacle/Obstacle4"), new Rectangle(900, 540, 200, 200));
            ListRectangle.Add(Ostacles4.rectangle);


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

            scrolling1.Update(10);
            scrolling2.Update(10);

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
                Ostacles1.rectangle.X = Ostacles2.rectangle.X + graphics.PreferredBackBufferWidth*3;
            }


            if (Ostacles2.rectangle.X + graphics.PreferredBackBufferWidth * 2 <= 0)
            {
                Ostacles2.rectangle.X = Ostacles1.rectangle.X + Ostacles1.texture.Width;

            }

            if (Ostacles3.rectangle.X + Ostacles4.texture.Width  <= 0)
            {
                Ostacles3.rectangle.X = Ostacles4.rectangle.X + graphics.PreferredBackBufferWidth;
            }

            
            if (Ostacles3.rectangle.X + graphics.PreferredBackBufferWidth *2<= 0)
            {
                Ostacles4.rectangle.X = Ostacles3.rectangle.X + Ostacles3.texture.Width;

            }
            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }
            Ostacles1.Update(10);
            Ostacles2.Update(10);


          
            Ostacles3.Update(10);
            Ostacles4.Update(10);




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
