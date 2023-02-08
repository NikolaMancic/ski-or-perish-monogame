﻿using EndlessRacer.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EndlessRacer
{
    internal class Player
    {
        private const string SpriteName = "player";
        private readonly Texture2D _sprite;

        private Vector2 _position;
        private readonly float _verticalVelocity = 1.0f;
        private KeyboardState _ks;

        public Player(Vector2 initialPosition)
        {
            _sprite = LevelSprites.Sprites[SpriteName];
            _position = initialPosition;
        }

        public void Update(GameTime gameTime)
        {
            _ks = Keyboard.GetState();

            if (_ks.IsKeyDown(Keys.Left))
            {
                _position.X -= _verticalVelocity;
            }

            if (_ks.IsKeyDown(Keys.Right))
            {
                _position.X += _verticalVelocity;
            }
        }

        public void Draw()
        {
            EngineComponents.SpriteBatch.Draw(_sprite, _position, Color.White);
        }
    }
}
