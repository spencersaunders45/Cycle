using System;


namespace Cycle.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score(string player)
        {
            AddPoints(0, player);
            SetPosition(player);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points, string player)
        {
            this.points += points;

            if (player == "player1")
            {
                SetText($"Player One: {this.points}");
            }
            else
            {
                SetText($"Player Two: {this.points}");
            }
            
        }

        private void SetPosition(string player)
        {
            if (player == "player1")
            {
                SetPosition(new Point(0, 0));
            }
            else
            {
                SetPosition(new Point(500, 0));
            }
        }

    }
}