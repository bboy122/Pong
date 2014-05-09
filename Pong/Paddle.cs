using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    class Paddle
    {

        //constants
        const int WIDTH = 10;
        const int HEIGHT = 50;
        const int SPEED = 5;

        //members
        Vector2 position;
        public Rectangle Boundary { get; set; }


        //constructor
        public Paddle(Vector2 Position)
        {
            //set members
            position = Position;
            Boundary = new Rectangle((int)position.X, (int)position.Y, WIDTH, HEIGHT);

        }

        public void Update(Keyboard keyboard)
        {

            if (keyboard.IsKeyPress(Keys.Up))
            {
                position.Y = position.Y - SPEED;
                Boundary = new Rectangle((int)position.X, (int)position.Y, 10, 50);
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw paddle
            spriteBatch.Draw(Game1.pixel, Boundary, Color.White);
        }

    }
}
