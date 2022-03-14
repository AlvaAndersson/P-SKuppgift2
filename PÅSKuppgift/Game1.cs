using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PÅSKuppgift
{
    public class Game1 : Game
    {
       

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D shipGreen_mannedBild;
        List<Rectangle> shipGreen_mannedPositioner = new List<Rectangle>();
        //float shipGreen_mannedSpeed = 3;
        Rectangle shipGreen_mannedRect;

        Texture2D character_0015Bild;
        Rectangle character_0015Rect;
        KeyboardState tangentBord = Keyboard.GetState();

        public Game1()
        {
            

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 1; y++)
                {
                    shipGreen_mannedPositioner.Add(new Rectangle(60 + 115 * x, 50 + 120 * y, 80, 80));
                }
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipGreen_mannedBild = Content.Load<Texture2D>("shipGreen_manned");
            shipGreen_mannedRect = new Rectangle(65, 50, shipGreen_mannedBild.Width / 2, shipGreen_mannedBild.Height / 2);

            character_0015Bild = Content.Load<Texture2D>("character_0015");
            character_0015Rect = new Rectangle(350, 420, 50, 50);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            tangentBord = Keyboard.GetState();

            FlyttaSkepp();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach (Rectangle shipGreen_mannnedPosition in shipGreen_mannedPositioner)
            {
                spriteBatch.Draw(shipGreen_mannedBild, shipGreen_mannnedPosition, Color.White);
                
            }

            spriteBatch.Draw(character_0015Bild, character_0015Rect, Color.White);
            
            spriteBatch.End();


            base.Draw(gameTime);
        }

        void FlyttaSkepp()
        {
            if (tangentBord.IsKeyDown(Keys.Right) == true)
            {
                character_0015Rect.X += 4;
            }
            if (tangentBord.IsKeyDown(Keys.Left) == true)
            {
                character_0015Rect.X -= 4;
            }
        }

       
    }
}
