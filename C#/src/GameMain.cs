using SwinGameSDK;
using static SwinGameSDK.SwinGame; // requires mcs version 4+, 
// using SwinGameSDK.SwinGame; // requires mcs version 4+, 

namespace Battleships
{
    public class GameMain
    {
        public static void Main()
        {
            //Open the game window
            OpenGraphicsWindow("Battle Ships", 800, 600);
            ShowSwinGameSplashScreen();

            // Load Resources
            GameResources.LoadResources();
 
            SwinGame.PlayMusic(GameResources.GameMusic("Background"));

            //Run the game loop
            while (false == WindowCloseRequested() | GameController.CurrentState == GameState.Quitting)
            {
                //Fetch the next batch of UI interaction
                GameController.HandleUserInput();

                //Draw onto the screen
                GameController.DrawScreen();
            }

            SwinGame.StopMusic();

            // Free Resources and Close Audio, to end the program.
            GameResources.FreeResources();
        }
    }
}
