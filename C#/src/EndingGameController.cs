using SwinGameSDK;

/// <summary>
/// The EndingGameController is responsible for managing the interactions at the end
/// of a game.
/// </summary>

static class EndingGameController
{

	/// <summary>
	/// Draw the end of the game screen, shows the win/lose state
	/// </summary>
    /// <remarks>
    /// Isuru: Updated to new swingame call
    /// </remarks>
	public static void DrawEndOfGame()
	{
		UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
		UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);

		Rectangle toDraw = new Rectangle();
		toDraw.X = 0;
		toDraw.Y = 250;
		toDraw.Width = SwinGame.ScreenWidth();
		toDraw.Height = SwinGame.ScreenHeight();
        string gameResult;
		if (GameController.HumanPlayer.IsDestroyed) {
            gameResult = "YOU LOSE!";
        } else {
            gameResult = "-- WINNER --";
		}
        SwinGame.DrawText(gameResult, Color.White, Color.Transparent,GameResources.GameFont ("ArialLarge"),FontAlignment.AlignCenter, toDraw);
	}

	/// <summary>
	/// Handle the input during the end of the game. Any interaction
	/// will result in it reading in the highsSwinGame.
	/// </summary>
    /// <remarks>
    /// Isuru: Updated keycodes
    /// </remarks>
	public static void HandleEndOfGameInput()
	{
        if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.ReturnKey) || SwinGame.KeyTyped(KeyCode.EscapeKey)) {
			HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
			GameController.EndCurrentState();
		}
	}

}
