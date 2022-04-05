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

        int scen = 0;
        SpriteFont arialFont;

        //Alien
        Texture2D shipGreen_mannedBild;
        List<Rectangle> shipGreen_mannedPositioner = new List<Rectangle>();
        List<Vector2> shipGreen_mannedSpeed = new List<Vector2>();
        Rectangle shipGreen_mannedRect;

        //Alien2
        Texture2D alien2Bild;
        List<Rectangle> alien2Positioner = new List<Rectangle>();
        //float shipGreen_mannedSpeed = 3;
        Rectangle alien2Rect;

        //Alien3
        Texture2D alien3Bild;
        List<Rectangle> alien3Positioner = new List<Rectangle>();
        //float shipGreen_mannedSpeed = 3;
        Rectangle alien3Rect;

        //Rymdskepp
        Texture2D character_0015Bild;
        Rectangle character_0015Rect;
        KeyboardState tangentBord = Keyboard.GetState();

        //Laser
        Texture2D laserBild;
        Rectangle laserHitbox;
        //Vector2 laserHastighet;
        //Vector2 laserPosition = new Vector2(); 

        // Mus
        MouseState mus = Mouse.GetState();
        MouseState gammalMus = Mouse.GetState();

        //Meny
        Texture2D buttonBild;
        Rectangle buttonRect;

        //Start text
        string startText = "Space invaders";
        Vector2 startPosition;

        //Avslut Text
        string avslutText = "Garttis du vann!";
        Vector2 avslutPosition;

        //Game over

        string overText = "GAME OVER";
        Vector2 overPosition;

        int Tid = 60;
        

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
                    shipGreen_mannedSpeed.Add(new Vector2(3 * x, 3 * y));
                }
            }

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 1; y++)
                {
                    alien2Positioner.Add(new Rectangle(65 + 100 * x, 120 + 120 * y, 50, 50));
                }
            }

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 1; y++)
                {
                    alien3Positioner.Add(new Rectangle(65 + 100 * x, 190 + 120 * y, 50, 50));
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

            //Alien3
            alien3Bild = Content.Load<Texture2D>("character_0003");
            alien3Rect = new Rectangle(65, 50, 50, 50);

            //Rymdskepp
            character_0015Bild = Content.Load<Texture2D>("character_0015");
            character_0015Rect = new Rectangle(350, 420, 50, 50);

            //Laser
            laserBild = Content.Load<Texture2D>("spaceMissiles_038");
            laserHitbox = new Rectangle(character_0015Rect.X + 17, character_0015Rect.Y, laserBild.Width, laserBild.Height);
            //laserPosition = new Vector2(character_0015Rect.X + 17, character_0015Rect.Y);

            //Startknapp
            buttonBild = Content.Load<Texture2D>("button");
            buttonRect = new Rectangle(400 - buttonBild.Width / 2, 360, buttonBild.Width, buttonBild.Height);

            //StartText
            arialFont = Content.Load<SpriteFont>("arial");
            startPosition = new Vector2(400 - arialFont.MeasureString(startText).X / 2, 100);

            //Avslut text
            avslutPosition = new Vector2(400 - arialFont.MeasureString(avslutText).X / 2, 100);

            //Game over text
            overPosition = new Vector2(400 - arialFont.MeasureString(overText).X / 2, 100);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);

            gammalMus = mus;
            mus = Mouse.GetState();

            //alienBort();

            
            switch (scen)
            {
                case 0:
                    UppdateraMeny();
                    break;

                case 1:
                    SpelSpel();
                        break;
            }



            
            

            tangentBord = Keyboard.GetState();

            //FlyttaSkepp();
        }

        protected override void Draw(GameTime gameTime)
        {
            
            switch (scen)
            {
                case 0:
                    ritaMeny();
                    break;
                case 1:
                    ritaSpel();
                    break;
                case 2:
                    vinnaSpel();
                    break;
                case 3:
                    GameOver();
                    break;
            }

            base.Draw(gameTime);
        }

        void FlyttaSkepp()
        {
            //skepp
            if (tangentBord.IsKeyDown(Keys.Right) == true)
            {
                character_0015Rect.X += 4;
                
            }
            if (tangentBord.IsKeyDown(Keys.Left) == true)
            {
                character_0015Rect.X -= 4;
                
            }

            //Laser
            if (laserHitbox.Y != 0)
            {
                laserHitbox.Y -= 6;
            }
            if (laserHitbox.Y == 0)
            {
                laserHitbox.Y = character_0015Rect.Y;
                laserHitbox.X = character_0015Rect.X + 17;
            }
        }

        void ritaMeny()
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(arialFont, startText, startPosition, Color.LimeGreen);
            spriteBatch.Draw(buttonBild, buttonRect, Color.White);
            spriteBatch.End();
        }

        void ritaSpel()
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

            foreach (Rectangle alien3Position in alien3Positioner)
            {
                spriteBatch.Draw(alien3Bild, alien3Position, Color.White);

            }

            spriteBatch.Draw(laserBild, laserHitbox, Color.White);

            spriteBatch.Draw(character_0015Bild, character_0015Rect, Color.White);



            spriteBatch.End();
        }

        
        void UppdateraMeny()
        {
            // if(Vänster musknapp precistryckt && muspekare över buttonbilden)
            // Byt scen till spelscen
            if (VänsterMusTryckt() == true && buttonRect.Contains(mus.Position) == true)
            {
                BytScen(1);
            }
        }
        void SpelSpel()
        {

            alienBort();
            FlyttaSkepp();
            alienFlytta();

            if (shipGreen_mannedPositioner.Count == 0)
            {
                BytScen(2);
                
            }
            
        }

        bool VänsterMusTryckt()
        {
            if (mus.LeftButton == ButtonState.Pressed && gammalMus.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void BytScen(int nyscen)
        {
            scen = nyscen;
        }
        
        void alienBort()
        {
            for (int i = 0; i < shipGreen_mannedPositioner.Count; i++)
            {
                Rectangle tempshipGreen_mannedPositioner = shipGreen_mannedPositioner[i];
                
                if (laserHitbox.Intersects(tempshipGreen_mannedPositioner))
                {
                    shipGreen_mannedPositioner.Remove(tempshipGreen_mannedPositioner);

                    laserHitbox.Y = character_0015Rect.Y;
                    laserHitbox.X = character_0015Rect.X + 17;
                }
               
            }

            for (int i = 0; i < alien2Positioner.Count; i++)
            {
                Rectangle tempalien2Positioner = alien2Positioner[i];

                if (laserHitbox.Intersects(tempalien2Positioner))
                {
                    alien2Positioner.Remove(tempalien2Positioner);

                    laserHitbox.Y = character_0015Rect.Y;
                    laserHitbox.X = character_0015Rect.X + 17;
                }

            }

            for (int i = 0; i < alien3Positioner.Count; i++)
            {
                Rectangle tempalien3Positioner = alien3Positioner[i];

                if (laserHitbox.Intersects(tempalien3Positioner))
                {
                    alien3Positioner.Remove(tempalien3Positioner);

                    laserHitbox.Y = character_0015Rect.Y;
                    laserHitbox.X = character_0015Rect.X + 17;
                }

            }

         

        }
        void alienFlytta()
        {
            Tid--;
            if (Tid <= 0)
            {


                Rectangle tempRect;


                for (int i = 0; i < alien3Positioner.Count; i++)
                {
                    tempRect = alien3Positioner[i];



                    if (tempRect.Y > 0)
                    {
                        tempRect.Y += 15;
                        alien3Positioner[i] = tempRect;
                    }


                   if(tempRect.Y == 430)
                    {
                        BytScen(3);
                    }
                }

                Tid = 60;
            }

        }

        void vinnaSpel()
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(arialFont, avslutText, avslutPosition, Color.LimeGreen);
            spriteBatch.End();
        }

        void GameOver()
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(arialFont, overText, overPosition, Color.LimeGreen);
            spriteBatch.End();
        }
        
    }
}
