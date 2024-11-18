using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Topic_4___Time_and_Sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bombTexture, pliersTexture, explosionTexture;
        SpriteFont timeFont;
        Rectangle bombRect;
        float seconds;
        SoundEffect explode;
        MouseState mouseState;
        Rectangle greenWire, redWire, pliersRect, windowRect;
        bool isExploding = false;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;

            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bombRect = new Rectangle(50, 50, 700, 400);
            windowRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            seconds = 15f;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bombTexture = Content.Load<Texture2D>("bomb");
            pliersTexture = Content.Load<Texture2D>("pliers");
            explosionTexture = Content.Load<Texture2D>("BigExplosion");
            timeFont = Content.Load<SpriteFont>("TimeFont");
            explode = Content.Load<SoundEffect>("explosion");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            seconds -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (isExploding == false)
            {
                if (seconds <= 0)
                {
                    seconds = 0f;
                    isExploding = true;
                }
            }
            if (isExploding)
            {
                explode.Play();
            }
           

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (isExploding)
            {
                _spriteBatch.Draw(explosionTexture, windowRect, Color.White);
            }

            _spriteBatch.Draw(bombTexture, bombRect, Color.White);
            _spriteBatch.DrawString(timeFont, seconds.ToString("00.0"), new Vector2(270, 200), Color.Black);
            if (isExploding)
            {
                _spriteBatch.Draw(explosionTexture, windowRect, Color.White);
            }

            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
