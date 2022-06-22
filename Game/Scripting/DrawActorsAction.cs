using System.Collections.Generic;
using Cycle.Game.Casting;
using Cycle.Game.Services;


namespace Cycle.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Actions
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("player1");
            List<Actor> snake1Segments = snake1.GetSegments();
            Snake snake2 = (Snake)cast.GetFirstActor("player2");
            List<Actor> snake2Segments = snake2.GetSegments();
            Actor score1 = cast.GetFirstActor("score1");
            Actor score2 = cast.GetFirstActor("score2");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(snake1Segments);
            videoService.DrawActors(snake2Segments);
            videoService.DrawActor(score1);
            videoService.DrawActor(score2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}