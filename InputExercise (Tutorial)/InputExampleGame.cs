﻿using InputExercise;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InputExercise__Tutorial_
{
    public class InputExampleGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Ball[] balls;
        private InputManager inputManager;
        

        public InputExampleGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            balls = new Ball[]
            {
               new Ball(this, Color.Red) { Position = new Vector2(250, 200)},
               new Ball(this, Color.Green) { Position = new Vector2(350, 200)},
               new Ball(this, Color.Blue) { Position = new Vector2(450, 200)}
            };
            inputManager = new InputManager();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (Ball b in balls) b.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            inputManager.Update(gameTime);

            if (inputManager.Exit) Exit();

            // TODO: Add your update logic here

            balls[0].Position += inputManager.Direction;

            if (inputManager.Warp) balls[0].Warp();
            

            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Ball b in balls) b.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
