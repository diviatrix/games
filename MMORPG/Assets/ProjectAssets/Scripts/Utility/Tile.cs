using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public enum tileType
    {
        Empty,
        Floor,
        Wall,
        Grass
    }
    public GameObject prefab;
    public tileType type;
    public int x;
    public int y;
}