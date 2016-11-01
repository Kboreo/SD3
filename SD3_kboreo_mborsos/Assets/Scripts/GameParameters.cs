//Authors: Kodey Boreo and Marshall Borsos
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

//Contains information about the current game such as player information, number of moves, etc.
public class GameParameters : MonoBehaviour
{

    public PlayerInfo[] players;        //Array which stores player information (name and character icon)
    public GameObject turnPrompt;       //Stores object in UI which denotes which player's turn it is
    public GameObject winPrompt;        //Stores object in UI which denotes who won or if it is a cat's game

    //When the game object this script is attached to is initialized...
    void Start()
    {
        //Initialize game board variables such as current player and the moves on the game board grid
        initializeGameBoard();
    }

    //At each frame...
    void Update()
    {
        turnPrompt = DataContainer.turnPrompt;      //Update the prompt for whose turn it is
        winPrompt = DataContainer.winPrompt;        //Update the prompt which shows whether a win or cat's game occurred
    }

    //Initialize variables used to track game state
    public void initializeGameBoard()
    {
        int[,] playerMoves = new int[3, 3];         //Create 3x3 array to represent the game board
        DataContainer.playerMoves = playerMoves;    //Assign each cell in the global array a value of zero through passing the initial 3x3 array
        players[0].playerIcon = DataContainer.player1Sprite;    //Assign character icon of player 1
        players[1].playerIcon = DataContainer.player2Sprite;    //Assign character icon of player 2
        DataContainer.players = players;    //Re-assign global data for players
        DataContainer.numOfMoves = 0;       //Reset the total number of moves to 0
        DataContainer.playerTurn = 0;       //Reset the current player to player 1


		//If the game object reference for the current player turn prompt is found, clear its text and pass the object reference for global data usage
		if (turnPrompt != null)
		{
			turnPrompt.GetComponent<Text> ().text = "It is " + DataContainer.players [DataContainer.playerTurn].playerName + "'s turn!";
			DataContainer.turnPrompt = turnPrompt;
		}

		//If the game object reference for the win/tie prompt is found, clear its text and pass the object reference for global data usage
		if (winPrompt != null)
		{
			winPrompt.GetComponent<Text>().text = "";
			DataContainer.winPrompt = winPrompt;
		}

        //Hide the popup which shows when a win or cat's game occurs
        GameObject.Find("Popup").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Popup").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Popup").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}