using UnityEngine;
using System.Collections;

//Change in how to load scenes found from http://answers.unity3d.com/questions/1109497/unity-53-how-to-load-current-level.html
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour {
    public GameParameters parameters;
	
    public void restartGame()
    {
        parameters.initializeGameBoard();
        SceneManager.LoadScene("Game Board");
    }

    public void newGameMode()
    {
        parameters.initializeGameBoard();
        SceneManager.LoadScene("Main Menu");
    }
}
