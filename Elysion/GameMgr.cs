using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

using System;

namespace Elysion
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 

    // 메인 구성
    public class GameMgr : Game
    {
        GraphicsDeviceManager graphics;
        List<SoundEffect> soundEffects;
        SpriteBatch spriteBatch;
        KeyboardState oldstate;
        KeyboardState currentstate;
        BMSReader rd;

        public GameMgr()
        {
            graphics = new GraphicsDeviceManager(this);
            soundEffects = new List<SoundEffect>();
            Content.RootDirectory = "Content";
            rd = new BMSReader();
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
            oldstate = Keyboard.GetState();

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
            
            soundEffects.Add(Content.Load<SoundEffect>("Sound/s1"));
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
            currentstate = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            else
            {
                if (currentstate.IsKeyDown(Keys.A) && !oldstate.IsKeyDown(Keys.A))
                {
                    var sd = soundEffects[0].CreateInstance();
                    //sd.IsLooped = false;
                    sd.Play();
                    //sd.Dispose();
                }
                if (currentstate.IsKeyDown(Keys.R) && !oldstate.IsKeyDown(Keys.R)) { rd.BMS파일분석(); }
                if (currentstate.IsKeyDown(Keys.Y) && !oldstate.IsKeyDown(Keys.Y)) { rd.노트시간계산(); }
                
                oldstate = currentstate;
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

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
