using System.Timers;
using Cycle.Game.Casting;

namespace Cycle.Game.Scripting
{
   class Timing
   {
      private static System.Timers.Timer aTimer;
      Cast cast;

      public Timing(Cast cast)
      {
         this.cast = cast;
         aTimer = new System.Timers.Timer(3000);
         aTimer.Elapsed += AddSegment;
         aTimer.AutoReset = true;
         aTimer.Enabled = true;
      }

      private void AddSegment(Object source, ElapsedEventArgs e)
      {
         Snake snake1 = (Snake)cast.GetFirstActor("player1");
         snake1.GrowTail(1, "player1");
         Snake snake2 = (Snake)cast.GetFirstActor("player2");
         snake2.GrowTail(1, "player2");
      }

      public void EndTimer()
      {
         aTimer.Stop();
         aTimer.Dispose();
      }
   }
}