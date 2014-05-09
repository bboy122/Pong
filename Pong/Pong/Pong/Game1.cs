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


namespace Pong
{
    public enum GameState
    {
        Menu,
        Play,
        Pause,
        GameOver,
        Exit,
        Options,
        Instructions



    }
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;//
        GameState gamestate; //game state
        SpriteFont MainMenu;  //Main Menu font
        Keyboard mykeyboard;
        public static Texture2D pixel;
        public static Vector2 vWindowSize;
        Ball ball;
        Paddle player1;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            mykeyboard = new Keyboard();
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
            gamestate = GameState.Menu;
            vWindowSize = new Vector2((float) Window.ClientBounds.Width, (float) Window.ClientBounds.Height);
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

            // TODO: use this.Content to load your game content here
            MainMenu = Content.Load<SpriteFont>("MainMenuFont");
            pixel = Content.Load<Texture2D>("WhitePixel");
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
            // Allows the game to exit
             if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
               this.Exit();

            // TODO: Add your update logic here
            mykeyboard.Update();
            if (gamestate == GameState.Menu)
            {
                if (mykeyboard.IsNewKeyPress(Keys.Enter))
                {
                    gamestate = GameState.Play;

                    player1 = new Paddle(new Vector2(20, 50));
                    ball = new Ball();
                }
                mykeyboard.Update();


                mykeyboard.Update();
 
                if (mykeyboard.IsNewKeyPress(Keys.F2))
                {

                    gamestate = GameState.Options;
                    
                    player1 = new Paddle (new Vector2(20, 50));
                    ball = new Ball();
                }
                mykeyboard.Update();
           
                if (gamestate == GameState .Menu)
                {
                    if (mykeyboard.IsNewKeyPress(Keys.I))
                    {
                        gamestate = GameState.Instructions;

                        player1 = new Paddle (new Vector2(20, 50));
                    }
                    mykeyboard.Update();

               
            
            //Check if Escape is Pressed to Exit  
            if (mykeyboard.IsNewKeyPress(Keys.Escape))
            {
                if (gamestate == GameState.Exit)
                player1 = new Paddle(new Vector2(20, 50));

                
                ball = new Ball();

                {



                }

                if (gamestate == GameState.Play)
                {
                    ball.Update();
                    player1.Update(mykeyboard);
                    //Put code to detect collisions with ball and paddle
                    //make method for ball class

                }


                {
                    base.Update(gameTime);
                }
            }

                

           
      
            
                  
           
                          
               
                

            
             
             
                     
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            // TODO: Add your drawing code here
            if (gamestate == GameState.Menu)
            switch (gamestate)
            {
                case GameState.Menu:
                string sMainMenu = "Press Enter to Begin ";
                Vector2 vMainMenu = MainMenu.MeasureString(sMainMenu);

                Vector2 vCentre = (vWindowSize - vMainMenu) / 2;
            //Draw the Main Menu on the screen
                spriteBatch.Begin();
                spriteBatch.DrawString(MainMenu, " Press Enter to Begin \n   Pong Game ",new Vector2 (170,100 ) , Color.White);
                spriteBatch.DrawString(MainMenu, "Press F2 To Go To Options", new Vector2 (170,300 ), Color.White);
                spriteBatch.DrawString(MainMenu, "Press Escape To Exit Game", vCentre , Color.White);
          
               
                

                   spriteBatch.End(); 
                


                break;
                case GameState.Play:
                spriteBatch.Begin();
                spriteBatch.DrawString(MainMenu,"Game Playing", new Vector2(100,100), Color.White);
                player1.Draw(spriteBatch);
                ball.Draw(spriteBatch);
                spriteBatch.End();
                break;

                case GameState.Pause:
                    break;
                case GameState.GameOver:
                    break;
                case GameState.Exit:
                    break;
                case GameState.Options:
                    break;
                
            }


            base.Draw(gameTime);
        }
    }
}
