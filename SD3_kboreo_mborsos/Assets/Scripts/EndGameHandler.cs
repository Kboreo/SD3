//Authors: Kodey Boreo and Marshall Borsos
using UnityEngine;
using System.Collections;

//Change in how to load scenes found from http://answers.unity3d.com/questions/1109497/unity-53-how-to-load-current-level.html
using UnityEngine.SceneManagement;

//Handles determining whether to begin a rematch or to direct user to main menu
public class EndGameHandler : MonoBehaviour {
    public GameParameters parameters;   //Used to call function to initialize variables related to current game state
	
    //Restart the game with same players, same game mode (player vs. player or player vs. computer)
    public void restartGame()
    {
        parameters.initializeGameBoard();       //Clear game state parameters
        SceneManager.LoadScene("Game Board");   //Reload game board to reset state of UI
    }

    //Return to main menu
    public void newGameMode()
    {
        parameters.initializeGameBoard();       //Clear game state parameters
        SceneManager.LoadScene("Main Menu");    //Load UI of the main menu
    }
}
