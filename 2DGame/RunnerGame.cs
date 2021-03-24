using RunnerGame.Entities;
using RunnerGame.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RunnerGame.System;

namespace RunnerGame
{
    public class RunnerGame : Game
    {
        private const string ASSET_NAME_SPRITESHEET = "TrexSpritesheet";

        public const int WINDOW_WIDTH = 600;
        public const int WINDOW_HEIGHT = 150;

        public const int PLAYER_START_POS_X = 0;
        public const int PLAYER_START_POS_Y = 135;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _tileSetTexture;

        private TRex _trex;

        private InputController _inputController;

        private GroundManager _groundManager;

        private EntityManager _entityManager;

        public RunnerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _entityManager = new EntityManager();
        }

        protected override void Initialize()
        {
            base.Initialize();

            // Resize window
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _tileSetTexture = Content.Load<Texture2D>(ASSET_NAME_SPRITESHEET);

            _trex = new TRex(_tileSetTexture, new Vector2(PLAYER_START_POS_X, PLAYER_START_POS_Y - TRex.TREX_DEFAULT_SPRITE_HEIGHT));
            _inputController = new InputController(_trex);

            _groundManager = new GroundManager(_tileSetTexture, _entityManager, _trex);

            _entityManager.AddEntity(_trex);
            _entityManager.AddEntity(_groundManager);

            _groundManager.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            _inputController.ProcessControls(gameTime);

            _entityManager.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();

            _entityManager.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
