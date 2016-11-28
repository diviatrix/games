using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Map : MonoBehaviour
{
    public string name;
    public int[,] tile_array;
    public List<List<GameObject>> tiles;
}
