using Lega_1.Core;
using Lega_1.Core.Virtual;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lega_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            VirtualSystem.Boot();
            VirtualSystem.Memory.Poke(0x000, 0x080, 0x00);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = new Texture2D(GraphicsDevice, 32, 32);
            VirtualSystem.Memory.Poke(0x000, 0b10010110);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Span<byte> span = VirtualSystem.Memory.Data;
            _texture.SetData(Util.FromByte(span.Slice(0x000, 0x080)));

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_texture, new Rectangle(0, 0, 512, 512), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}