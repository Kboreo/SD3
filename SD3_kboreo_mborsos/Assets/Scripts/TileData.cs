//Authors: Kodey Boreo and Marshall Borsos
using UnityEngine;
using System.Collections;

//Stores data about the selected tile on the game board
public class TileData : MonoBehaviour {
    public int row;             //Vertical position in the int game board array
    public int column;          //Horizontal position in the int game board array
    public GameObject tileObj;  //Object representing selected tile (used to aid in filling tile with player's character image)
}
