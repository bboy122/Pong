﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Pong
{

    class Ball
    {
        //initial/default ball speed and size
        private const float BALLSPEED = 4;
        private const int BALLSIZE = 10;

        //private member variables
        private float speed;
        private Vector2 position;
        private Vector2 velocity;
        public Rectangle Boundary { get; set; }

        //constructor
        public Ball()
        {
            //Reset the ball
            Reset();
        }

        //Reset Method
        //This method initializes the ball speed, position, angle, velocity and boundary
        private void Reset()
        {
            //set initial speed
            speed = BALLSPEED;

            velocity = new Vector2(1f, 1f);
            velocity = speed * velocity;

            //position in centre of screen
            position = new Vector2((Game1.vWindowSize.X - BALLSIZE) / 2, (Game1.vWindowSize.Y - BALLSIZE) / 2);  //use window size and ball size

            Boundary = new Rectangle((int)position.X, (int)position.Y, BALLSIZE, BALLSIZE);


        }

        //Update gets called in the Game1 update method
        public void Update()
        {
            //Check if the ball is to bounce off the top or bottom portion of screen and change the velocity (velocity.Y = velocity.Y * -1)
            //If the ball is past the left edge or past the right edge of the screen then award a point to respective player (don't forget to reset after a goal)
            //Put this code here


            if (Boundary.Top <= 0 || Boundary.Bottom >= Game1.vWindowSize.Y)
            {
                velocity.Y *= -1;
            }

            if (Boundary.Left <= 0 || Boundary.Right >= Game1.vWindowSize.X)
            {

                if (speed < 12)
                {
                    velocity.X *= -1.1f;
                    speed = (float)velocity.Length();
                }
                else
                {
                    velocity.X *= -1;
                }
            }


            //get new position and boundary
            position += velocity;
            Boundary = new Rectangle((int)position.X, (int)position.Y, BALLSIZE, BALLSIZE);

        }

        //call this method in the draw method of Game1 class
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw Ball
            spriteBatch.Draw(Game1.pixel, Boundary, Color.White);
        }


    }
}
