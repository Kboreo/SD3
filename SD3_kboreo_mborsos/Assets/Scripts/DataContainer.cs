using UnityEngine;
using System.Collections;

public class DataContainer : ScriptableObject {
    public static PlayerInfo[] players;
    public static int numOfMoves;
    public static GameObject turnPrompt;
    public static GameObject winPrompt;
    public static int playerTurn;
    public static int[,] playerMoves;
}
