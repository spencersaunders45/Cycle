using Cycle.Game.Casting;
using Cycle.Game.Directing;
using Cycle.Game.Scripting;
using Cycle.Game.Services;
using System.Timers;


namespace Cycle
{
   /// <summary>
   /// The program's entry point.
   /// </summary>
   class Program
   {
      /// <summary>
      /// Starts the program using the given arguments.
      /// </summary>
      /// <param name="args">The given arguments.</param>
      static void Main(string[] args)
      {
         // create the cast
         Cast cast = new Cast();
         cast.AddActor("player1", new Snake("player1"));
         cast.AddActor("player2", new Snake("player2"));
         cast.AddActor("score1", new Score("player1"));
         cast.AddActor("score2", new Score("player2"));

         // create the services
         KeyboardService keyboardService = new KeyboardService();
         VideoService videoService = new VideoService(false);

         // create the script
         Script script = new Script();
         script.AddAction("input", new ControlActorsAction(keyboardService));
         script.AddAction("update", new MoveActorsAction());
         script.AddAction("update", new HandleCollisionsAction());
         script.AddAction("output", new DrawActorsAction(videoService));

         // start the game
         Director director = new Director(videoService);
         director.StartGame(cast, script);
      }

   }
}