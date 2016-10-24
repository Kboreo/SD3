using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void makeMove(TileData tile)
    {
        string endResult = "";

        DataContainer.numOfMoves++;
        tile.tileObj.GetComponent<Image>().sprite = DataContainer.players[DataContainer.playerTurn].playerIcon;
        tile.tileObj.GetComponent<Button>().interactable = false;
        DataContainer.playerMoves[tile.row, tile.column] = DataContainer.playerTurn + 1;

        if (DataContainer.numOfMoves >= 5)
            endResult = analyzeMoves();

        if (endResult == "")
            DataContainer.turnPrompt.GetComponent<Text>().text = nextTurn();
    }

    string analyzeMoves()
    {
        string result = "";
        int winCount = 0;

        //Vertical winning move check
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 3; i++)
            {
                if (DataContainer.playerMoves[i, j] == DataContainer.playerTurn + 1)
                    winCount++;
                else
                    break;
            }
            if (winCount == 3)
                break;
            else
                winCount = 0;
        }

        //Check for horizontal winning move only if there was no vertical winning move
        if (winCount != 3)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (DataContainer.playerMoves[i, j] == DataContainer.playerTurn + 1)
                        winCount++;
                    else
                        break;
                }
                if (winCount == 3)
                    break;
                else
                    winCount = 0;
            }
        }

        //Check for diagonal winning move only if there was no horizontal winning move
        if (winCount != 3)
        {
            for (int i = 0; i < 3; i++)
            {
                int j = i;

                if (DataContainer.playerMoves[i, j] == DataContainer.playerTurn + 1)
                    winCount++;
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
            for (int j = 0; j < 3; j++)
            {
                int i = 2 - j;

                if (DataContainer.playerMoves[i, j] == DataContainer.playerTurn + 1)
                    winCount++;
                else
                {
                    winCount = 0;
                    break;
                }
            }
        }

        if (winCount == 3)
            result = DataContainer.players[DataContainer.playerTurn].playerName + " Wins!!!!";
        else
            if (checkEmptyTiles() == false)
                result = "Cat's Game!!!!";

        return result;
    }

    string nextTurn()
    {
        string turnPrompt = "";

        return turnPrompt;
    }

    bool checkEmptyTiles()
    {
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (DataContainer.playerMoves[i, j] == 0)
                    return true;

        return false;
    }
}
