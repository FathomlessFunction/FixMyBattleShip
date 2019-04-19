
using SwinGameSDK;
static class GameLogic
{
	public static void Main()
	{
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        //Opens a new Graphics Window
        SwinGame.OpenGraphicsWindow("Battle Ships", WINDOW_WIDTH, WINDOW_HEIGHT);

		//Load Resources
		GameResources.LoadResources();

		SwinGame.PlayMusic(GameResources.GameMusic("Background"));

		//Game Loop
		do {
			GameController.HandleUserInput();
			GameController.DrawScreen();
		} while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}