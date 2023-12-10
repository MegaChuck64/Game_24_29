using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public abstract class BaseGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatchManager _spriteBatchManager;
        private SceneManager _sceneManager;
        private InputManager _inputManager;
        public Color BackgroundColor { get; set; } = Color.CornflowerBlue;
        public Vector2 CenterScreen => new(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
        public BaseGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Init();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatchManager = new SpriteBatchManager();
            _spriteBatchManager.AddBatch("default", new SpriteBatch(GraphicsDevice));
            _inputManager = new InputManager();
            _sceneManager = new SceneManager();
            Load(ref _spriteBatchManager, ref _sceneManager);
        }

        protected override void Update(GameTime gameTime)
        {
            var dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _inputManager.Update();
            Update(dt, _inputManager);
            _sceneManager.Update(dt, _inputManager);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackgroundColor);
            PreDraw(_spriteBatchManager);
            Draw(_spriteBatchManager);
            _sceneManager.Draw(_spriteBatchManager);
            PostDraw(_spriteBatchManager);
            base.Draw(gameTime);
        }


        public abstract void Load(ref SpriteBatchManager spriteBatchManager, ref SceneManager sceneManager);
        public abstract void Init();
        public abstract void Update(float dt, InputManager input);
        public abstract void PreDraw(SpriteBatchManager spriteBatchManager);
        public abstract void Draw(SpriteBatchManager spriteBatchManager);
        public abstract void PostDraw(SpriteBatchManager spriteBatchManager);

    }
}
