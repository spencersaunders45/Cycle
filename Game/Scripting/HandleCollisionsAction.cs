using System;
using System.Collections.Generic;
using System.Data;
using Cycle.Game.Casting;
using Cycle.Game.Services;


namespace Cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Actions
    {
        private bool isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                CollisionHandler(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Calls the segment collision handler for both players
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void CollisionHandler(Cast cast)
        {
            HandleSelfCollisions(cast, "player1");
            HandleSegmentCollisions(cast, "player1");
            HandleSelfCollisions(cast, "player2");
            HandleSegmentCollisions(cast, "player2");
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSelfCollisions(Cast cast, string player)
        {
            Snake snake = (Snake)cast.GetFirstActor(player);
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with a segment of the other snake
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast, string player)
        {
            Snake snakeX;
            Snake snakeY;
            Actor head;
            List<Actor> body;

            if (player == "player1")
            {
                snakeX = (Snake)cast.GetFirstActor(player);
                snakeY = (Snake)cast.GetFirstActor("player2");
                head = snakeX.GetHead();
                body = snakeY.GetBody();
            }
            else
            {
                snakeX = (Snake)cast.GetFirstActor(player);
                snakeY = (Snake)cast.GetFirstActor("player1");
                head = snakeX.GetHead();
                body = snakeY.GetBody();
            }

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                }
            }
        }

        /// <summary>
        /// Displays game over message and turns everything to white
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake1 = (Snake)cast.GetFirstActor("player1");
                List<Actor> snake1Segments = snake1.GetSegments();

                Snake snake2 = (Snake)cast.GetFirstActor("player2");
                List<Actor> snake2Segments = snake2.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in snake1Segments)
                {
                    segment.SetColor(Constants.WHITE);
                }

                foreach (Actor segment in snake2Segments)
                {
                    segment.SetColor(Constants.WHITE);
                }


            }
        }

    }
}