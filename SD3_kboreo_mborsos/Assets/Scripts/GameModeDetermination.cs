//Authors: Kodey Boreo and Marshall Borsos
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameModeDetermination : MonoBehaviour {

	//Function for when user clicks "Player vs Computer" button
	public void playerVsPlayerButton_Click()
	{
		//Disables current group object to clear canvas 
		GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;

		//Shows the Start Game menu by enabling canvas group
		GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().alpha = 1;
		GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().interactable = true;
		GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	//Function for when user clicks "Player vs Computer" button
	public void playerVsComputerButton_Click()
	{		
		//Enables computer logic
		selNumOfPlayers(1);

		//Disables current group object to clear canvas 
		GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().alpha = 0;
		GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().interactable = false;
		GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;

		//Shows the "Start Game" menu by enabling canvas group
		GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().alpha = 1;
		GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().interactable = true;
		GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().blocksRaycasts = true;

	}

	//Function for when user clicks "Cancel" button located on the Start Game Menu
	public void cancelSelection()
	{

        if (GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().alpha == 0)
        {
            //Disables computer logic
            selNumOfPlayers(0);

            //Disables the canvas group to clear the canvas
            GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().interactable = false;
            GameObject.Find("Start Game Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;

            //Goes back to previous "Game Mode" menu by enabling canvas group
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().interactable = true;
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            //Clears character icons
            selCharacters(0);
            //Disables the canvas group to clear the canvas
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().interactable = false;
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;

            //Goes back to previous "Character Mode" menu by enabling canvas group
            GameObject.Find("Character Mode Menu").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.Find("Character Mode Menu").GetComponent<CanvasGroup>().interactable = true;
            GameObject.Find("Character Mode Menu").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
	}

	//Function that changes enables or disables computer logic (0 = computerLogic is disabled, 1 = computerLogic enabled)
	public void selNumOfPlayers(int players)
	{		
		if (players == 0) 
		{
			//Disables computer logic
			DataContainer.computerLogic = false;
		}
		else if (players == 1)
		{
			//Enables computer logic
			DataContainer.computerLogic = true;
		}
	}

    public void selCharacters(int characterMode)
    {
        switch (characterMode)
        {
            case 0:
                DataContainer.player1Sprite = null;
                DataContainer.player2Sprite = null;
                break;
            case 1:
                DataContainer.player1Sprite = Resources.Load<Sprite>("Images/Shape - X");
                DataContainer.player2Sprite = Resources.Load<Sprite>("Images/Shape - O");
                break;
            case 2:
                DataContainer.player1Sprite = Resources.Load<Sprite>("Images/Shape - Sweet");
                DataContainer.player2Sprite = Resources.Load<Sprite>("Images/Shape - Givental");
                break;
        }

        if(characterMode != 0)
        {
            //Disables current group object to clear canvas 
            GameObject.Find("Character Mode Menu").GetComponent<CanvasGroup>().alpha = 0;
            GameObject.Find("Character Mode Menu").GetComponent<CanvasGroup>().interactable = false;
            GameObject.Find("Character Mode Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;

            //Shows the "Game Mode" menu by enabling canvas group
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().interactable = true;
            GameObject.Find("Game Mode Menu").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
            

    }

	public void startGame()
	{
		//Load "Game Board" scene. 
		SceneManager.LoadScene("Game Board");
	}
}
