//Authors: Kodey Boreo and Marshall Borsos
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
}
