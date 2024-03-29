using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using The_Nights_Of_Lurnia.CameraService;
using The_Nights_Of_Lurnia.Map;

namespace The_Nights_Of_Lurnia
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class LurniaGame : Microsoft.Xna.Framework.Game
    {
        // Managers & Services
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Zone
        private Map.Zone gameZone;

        // Sprites & spritesheets
        private Spritesheet SimpleSpritesheet;

        // Keyboard states
        KeyboardState previousKeyboardState;
        KeyboardState currentKeyboardState;

        public LurniaGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 512;
            graphics.PreferredBackBufferWidth = 512;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Zone init
            gameZone = new Zone(this,31,31);
            Components.Add(gameZone);

            // Create the first spreadsheet to be used
            SimpleSpritesheet = new Spritesheet();

            // Publish the services to be available to the entire application.
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            Services.AddService(typeof(Spritesheet), SimpleSpritesheet);

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Enter) && previousKeyboardState.IsKeyDown(Keys.Enter) == false)
            {// If enter is being pressed and was not pressed before, this is to avoid spamming recreations while briefly holding the key
                gameZone.ReCreateMap();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Left) && previousKeyboardState.IsKeyDown(Keys.Left) == false)
            {
                Camera.MoveLeft();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Right) && previousKeyboardState.IsKeyDown(Keys.Right) == false)
            {
                Camera.MoveRight();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Up) && previousKeyboardState.IsKeyDown(Keys.Up) == false)
            {
                Camera.MoveUp();
            }
            if (currentKeyboardState.IsKeyDown(Keys.Down) && previousKeyboardState.IsKeyDown(Keys.Down) == false)
            {
                Camera.MoveDown();
            }


            previousKeyboardState = currentKeyboardState;

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

            base.Draw(gameTime);

            spriteBatch.End();

        }
    }
}
