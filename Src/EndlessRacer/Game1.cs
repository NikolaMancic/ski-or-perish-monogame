﻿using EndlessRacer.Environment;
using EndlessRacer.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EndlessRacer
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _playerMovingSprite;
        private Texture2D _playerJumpingSprite;

        private Player _player;
        private Level _level;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            _player = new Player(new Vector2(_graphics.PreferredBackBufferWidth / 2, 100));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _playerMovingSprite = Content.Load<Texture2D>("Player");
            _playerJumpingSprite = Content.Load<Texture2D>("PlayerJumping");

            LevelSprites.Sprites.Add("player-moving", _playerMovingSprite);
            LevelSprites.Sprites.Add("player-jumping", _playerJumpingSprite);

            _level = new Level(LevelImporter.Import(Content));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _player.Update(gameTime);
            _level.Update(gameTime, _player);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Snow);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _level.Draw(_spriteBatch);
            _player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}