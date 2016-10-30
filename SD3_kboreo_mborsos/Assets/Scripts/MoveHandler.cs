//Authors: Kodey Boreo and Marshall Borsos
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*Handles filling in of tiles based on user input, checking if there are empty spaces in the game board grid, checking for winning moves,
  reporting a winning or cat's game, and setting parameters for the next player's turn if no win/cat's game occurred*/
public class MoveHandler : MonoBehaviour {

	/*Triggered when player selects an empty tile
      Passes tile gameObject, row in which tile is located, column in which tile is located
      Handles calls to analyze player movements, filling tile with player image, and reporting a win/cat's game or setting the parameters for the
        next player's turn*/
    public void makeMove(TileData tile)
    {
        string endResult = "";  //Contains result of analyzing player moves

        DataContainer.numOfMoves++;     //Increment total move counter

        tile.tileObj.GetComponent<Image>().sprite = DataContainer.players[DataContainer.playerTurn].playerIcon; //Fill empty tile image with corresponding player image
        tile.tileObj.GetComponent<Button>().interactable = false;                                               //Disable click property of tile to prevent re-selection
        DataContainer.playerMoves[tile.row, tile.column] = DataContainer.playerTurn + 1;                        //Fill int version of game board array with the corresponding player number at the location of the tile on the board

        //Only analyze player moves if 5 or more total moves have been made (since at least 5 moves must occur before a win can happen)
        if (DataContainer.numOfMoves >= 5)
            endResult = analyzeMoves();

        //If no win or cat's game occurred, set parameters and indicate that it is the next player's turn
        if (endResult == "")
            DataContainer.turnPrompt.GetComponent<Text>().text = nextTurn();
        //Otherwise, show the popup and report who won or that a cat's game occurred
        else
        {
            DataContainer.winPrompt.GetComponent<Text>().text = endResult;
            GameObject.Find("Popup").GetComponent<CanvasGroup>().alpha = 1;
            GameObject.Find("Popup").GetComponent<CanvasGroup>().interactable = true;
            GameObject.Find("Popup").GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }

    //Analyze the int game board array to see if a winning move has occurred
    string analyzeMoves()
    {
        string result = "";     //Stores result if win or cat's game occurred
        int winCount = 0;       //If this equals 3, a win has occurred

        //Vertical winning move check
        //For each column
        for (int j = 0; j < 3; j++)
        {   
            //Check each row
            for (int i = 0; i < 3; i++)
            {
                //If the cell contains the current player's number, increment the win counter
                if (DataContainer.playerMoves[i, j] == DataContainer.playerTurn + 1)
                    winCount++;
                //Otherwise, break because a win has not occurred in that column
                else
                    break;
            }
            //Quit looking for a win if a win occurred in the current column
            if (winCount == 3)
                break;
            //Otherwise, reset the win counter and check the next column if possible
            else
                winCount = 0;
        }

        //Check for horizontal winning move only if there was no vertical winning move
        if (winCount != 3)
        {
            //For each row
            for (int i = 0; i < 3; i++)
            {
                //Check each column
                for (int j = 0; j < 3; j++)
                {
                    //If the cell contains the current player's number, increment the win counter
                    if (DataContainer.playerMoves[i, j] == DataContainer.playerTurn + 1)
                        winCount++;
                    //Otherwise, break because a win has not occurred in that row
                    else
                        break;
                }
                //Quit looking for a win if a win occurred in the current row
                if (winCount == 3)
                    break;
                //Otherwise, reset the win counter and check the next row if possible
                else
                    winCount = 0;
            }
        }

        //Check for diagonal winning move only if there was no horizontal winning move
        if (winCount != 3)
        {
            //For each row
            for (int i = 0; i < 3; i++)
            {
                int j = i;      //Check the column that is the same position as the row (i.e., check positions 0,0 , 1,1 , 2,2)

                //If the cell contains the current player's number, increment the win counter
                if (DataContainer.playerMoves[i, j] == DataContainer.playerTurn + 1)
                    winCount++;
                //Otherwise, exit the loop and reset the win counter as no diagonal win occurred
                else
                {
                    winCount = 0;
                    break;
                }
            }
        }

        //Check for anti-diagonal winning move only if there was no diagonal winning move
        if (winCount != 3)
        {
            //For each column
            for (int j = 0; j < 3; j++)
            {
                int i = 2 - j;  //Check each row that is the inverse of that column (i.e. check 2,0 , 1,1 , 0,2)

                //If the cell contains the current player's number, increment the win counter
                if (DataContainer.playerMoves[i, j] == DataContainer.playerTurn + 1)
                    winCount++;
                //Otherwise, exit the loop and reset the win counter as no anti-diagonal win occurred
                else
                {
                    winCount = 0;
                    break;
                }
            }
        }

        //If the win counter equals 3, a win occurred; therefore, report which player won
        if (winCount == 3)
            result = DataContainer.players[DataContainer.playerTurn].playerName + " Wins!!!!";
        //Otherwise, determine if there is a cat's game
        else
            //If there are no empty tiles left in the array, a cat's game occurred; report cat's game
            if (checkEmptyTiles() == false)
                result = "Cat's Game!!!!";

        return result;
    }

    //Set parameters for next player's turn and prompt that player to make a move
    string nextTurn()
    {
		//Initialize the turnPrompt String
        string turnPrompt = "";

		//Check if it is player one's or player two's turn and then either increment or decrement depending on value
		if (DataContainer.playerTurn == 1)
		{
			DataContainer.playerTurn--;
			//Set prompt so that it tells user that it is player one's turn 
			turnPrompt = "It is " + DataContainer.players[DataContainer.playerTurn].playerName + "'s turn!";
		}
		else if (DataContainer.playerTurn == 0)
		{
			DataContainer.playerTurn++;
			//Set prompt so that it tells user that it is player one's turn 
			turnPrompt = "It is " + DataContainer.players[DataContainer.playerTurn].playerName + "'s turn!";
		}

		// return the turnPrompt string back. 
        return turnPrompt;
    }

    //Check if there are any remaining empty tiles in the grid array
    bool checkEmptyTiles()
    {
        //Go through the grid array tile-by-tile
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                //If an empty cell is found, return true to indicate there is an empty spot in the game board and moves can still be made
                if (DataContainer.playerMoves[i, j] == 0)
                    return true;

        //Otherwise, return false to indicate no more moves can be made
        return false;
    }
}
