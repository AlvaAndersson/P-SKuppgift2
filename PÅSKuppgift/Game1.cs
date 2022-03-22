using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace PÅSKuppgift
{
    public class Game1 : Game
    {
       

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Alien
        Texture2D shipGreen_mannedBild;
        List<Rectangle> shipGreen_mannedPositioner = new List<Rectangle>();
        //float shipGreen_mannedSpeed = 3;
        Rectangle shipGreen_mannedRect;

        //Alien2
        Texture2D alien2Bild;
        List<Rectangle> alien2Positioner = new List<Rectangle>();
        //float shipGreen_mannedSpeed = 3;
        Rectangle alien2Rect;

        //Rymdskepp
        Texture2D character_0015Bild;
        Rectangle character_0015Rect;
        KeyboardState tangentBord = Keyboard.GetState();

        //Laser
        Texture2D laserBild;
        Rectangle laserHitbox;
        Vector2 laserHastighet;
        Vector2 laserPosition = new Vector2(); 

        Texture2D buttonBild;
        Rectangle buttonRect;

        //Start text
        string start = "Space invaders";
        Vector2 startPosition;
        SpriteFont arial;

        public Game1()
        {
            

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 1; y++)
                {
                    shipGreen_mannedPositioner.Add(new Rectangle(65 + 100 * x, 50 + 120 * y, 50, 50));
                }
            }

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 1; y++)
                {
                    alien2Positioner.Add(new Rectangle(65 + 100 * x, 120 + 120 * y, 50, 50));
                }
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
           //Aliens översta raden
            spriteBatch = new SpriteBatch(GraphicsDevice);
            shipGreen_mannedBild = Content.Load<Texture2D>("character_0001");
            shipGreen_mannedRect = new Rectangle(65, 50, 50, 50);

            //Alien2
            alien2Bild = Content.Load<Texture2D>("character_0005");
            alien2Rect = new Rectangle(65, 50, 50, 50);

            //Rymdskepp
            character_0015Bild = Content.Load<Texture2D>("character_0015");
            character_0015Rect = new Rectangle(350, 420, 50, 50);

            //Laser
            laserBild = Content.Load<Texture2D>("spaceMissiles_038");
            laserHitbox = new Rectangle(character_0015Rect.X + 17, character_0015Rect.Y, laserBild.Width, laserBild.Height);
            laserPosition = new Vector2(character_0015Rect.X + 17, character_0015Rect.Y);

            //Startknapp
            buttonBild = Content.Load<Texture2D>("button");
            buttonRect = new Rectangle(400 - buttonBild.Width / 2, 360, buttonBild.Width, buttonBild.Height);

            //StartText
           // startPosition = new Vector2(400 - arial.MeasureString(start).X / 2, 100);
            

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);


            if (laserPosition.Y != 0)
            {
                laserPosition.Y -= 4; 
            }
            if (laserPosition.Y == 0)
            {
                laserPosition = new Vector2(character_0015Rect.X + 17, character_0015Rect.Y);
            }
            

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

            foreach (Rectangle alien2Position in alien2Positioner)
            {
                spriteBatch.Draw(alien2Bild, alien2Position, Color.White);

            }

            spriteBatch.Draw(laserBild, laserPosition, Color.White);

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

        void startMeny()
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(arial, start, startPosition, Color.White);
            spriteBatch.Draw(buttonBild, buttonRect, Color.White);
            spriteBatch.End();
        }

        void UppdateraMeny()
        {
            // if(Vänster musknapp precistryckt && muspekare över buttonbilden)
            // Byt scen till spelscen
        }

        void alienBort()
        {
            for (int i = 0; i < shipGreen_mannedPositioner.count; i++)
            {

            }
        }
       
    }
}
