using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace _2048_Evolution
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;
        Texture2D title;
        Texture2D table;
        Texture2D over, win;

        GameSystem gameSystem;

        SoundEffect p;


        enum GameState
        {
            MainMenu,
            Playing,
        }
        GameState CurrentGameState = GameState.MainMenu;

        // Screen Adjustments

        Button btnPlay;
        Button btnMenu;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 700;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            gameSystem = new GameSystem();

            p = Content.Load<SoundEffect>("Sound/Sound1");
            gameSystem.pop = p;
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
            background = Content.Load<Texture2D>("Images/PantallaMenu");
            IsMouseVisible = true;
            btnPlay = new Button(Content.Load<Texture2D>("Images/Start"), graphics.GraphicsDevice);
            btnPlay.setPosition(new Vector2(350, 300));
           
            title = Content.Load<Texture2D>("Images/Tittle");
            table = Content.Load<Texture2D>("Images/GameTable");

            btnMenu = new Button(Content.Load<Texture2D>("Images/Return"), graphics.GraphicsDevice);
            btnMenu.setPosition(new Vector2(10, 10));

            over = Content.Load<Texture2D>("Images/Over");
            win = Content.Load<Texture2D>("Images/Win");

            gameSystem.textureObj.Add(Content.Load <Texture2D>("Images/Obj1"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj3"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj4"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj5"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj6"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj7"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj8"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj9"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj10"));
            gameSystem.textureObj.Add(Content.Load<Texture2D>("Images/Obj11"));

            Song song = Content.Load<Song>("Sound/Music1");  // Put the name of your song here instead of "song_title"
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GameState.MainMenu:
                    if (btnPlay.isClicked == true)
                    {
                        CurrentGameState = GameState.Playing;
                        gameSystem.init();
                    }
                    btnPlay.Update(mouse, 1);
                    break;

                case GameState.Playing:
                    gameSystem.update();

                    if (btnMenu.isClicked == true)
                    {
                        CurrentGameState = GameState.MainMenu;
                    }
 
                    btnMenu.Update(mouse, 2);
                    break;
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

            spriteBatch.Draw(background, new Rectangle(0, 0, 900, 700), Color.White);
            switch (CurrentGameState)
            {
                //-------MENU
                case GameState.MainMenu:
                    spriteBatch.Draw(title, new Rectangle(255, 30, 350, 250), Color.White);
                    btnPlay.Draw(spriteBatch);
                    break;

                //-------GAME
                case GameState.Playing:
                    
                    spriteBatch.Draw(table, new Rectangle(100, 100, 700, 580), Color.White);
                    btnMenu.Draw(spriteBatch);

                    if (gameSystem.win == false)
                    {
                        if (gameSystem.cont < 16)
                            gameSystem.Draw(spriteBatch);
                        else
                            spriteBatch.Draw(over, new Rectangle(200, 200, 500, 250), Color.White);
                    }
                    else
                        spriteBatch.Draw(win, new Rectangle(200, 200, 500, 250), Color.White);
                    break;
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
