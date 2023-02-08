﻿using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EndlessRacer.Environment
{
    internal class Tree
    {
        private readonly SpriteBatch _spriteBatch;
        private readonly Texture2D _sprite;

        private Vector2 Position { get; set; }

        public Tree(SpriteBatch spriteBatch, Texture2D sprite, Vector2 initialPosition)
        {
            _spriteBatch = spriteBatch;
            _sprite = sprite;
            Position = initialPosition;

            Debug.WriteLine($"Hi. I'm a tree. My position is: {Position.X}, {Position.Y}");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw()
        {
            _spriteBatch.Draw(_sprite, Position, Color.White);
        }
    }
}