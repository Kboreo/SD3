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
        return result;
    }

    string nextTurn()
    {
        string turnPrompt = "";

        return turnPrompt;
    }
}
