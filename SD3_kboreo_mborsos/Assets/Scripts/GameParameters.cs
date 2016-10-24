using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Text;

//Contains information about the current game such as player information, number of moves, etc.
public class GameParameters : MonoBehaviour
{

    public PlayerInfo[] players;
    public GameObject turnPrompt;
    public GameObject winPrompt;

    void Start()
    {
        int[,] playerMoves = new int [3, 3];
        DataContainer.playerMoves = playerMoves;

        if (turnPrompt != null)
        {
            turnPrompt.GetComponent<Text>().text = "";
            DataContainer.turnPrompt = turnPrompt;
        }
        if (winPrompt != null)
        {
            winPrompt.GetComponent<Text>().text = "";
            DataContainer.winPrompt = winPrompt;
        }

        DataContainer.players = players;
        DataContainer.numOfMoves = 0;
        DataContainer.playerTurn = 0;
    }

    void Update()
    {
        turnPrompt = DataContainer.turnPrompt;
        winPrompt = DataContainer.winPrompt;
    }
}