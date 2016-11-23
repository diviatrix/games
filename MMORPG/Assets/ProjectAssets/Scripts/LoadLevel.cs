using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LoadLevel : MonoBehaviour {

    public List<GameObject> map_Tiles= new List<GameObject>();

    public Tile[,] map = new Tile[16, 16];


    public int[,] hMap =
    {
        { 0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0},
        { 2,1,1,1,1,1,1,1,2,1,1,1,1,1,1,2 },
        { 2,1,1,1,1,1,1,1,2,2,2,2,1,1,1,2 },
        { 2,1,1,2,2,1,1,1,1,1,1,1,1,1,1,2 },
        { 2,1,1,1,2,2,2,1,1,1,1,1,2,2,2,2 },
        { 2,1,1,1,1,1,2,2,1,1,1,1,2,1,1,2 },
        { 2,1,1,1,1,1,1,2,1,1,1,1,2,1,1,2 },
        { 2,1,1,1,1,1,1,2,1,1,1,1,2,1,1,1 },
        { 2,1,1,1,1,1,1,2,1,1,1,1,2,1,1,1 },
        { 2,1,1,1,1,1,1,2,1,1,2,1,2,1,1,2 },
        { 2,1,1,1,1,1,1,2,1,1,2,1,2,1,1,2 },
        { 2,1,1,1,1,1,2,2,1,1,2,1,2,1,1,2 },
        { 2,1,1,1,1,1,2,1,1,1,2,1,2,1,1,2 },
        { 2,1,1,1,1,2,2,1,1,1,2,1,2,1,1,2 },
        { 2,1,1,2,2,2,1,1,1,1,2,1,1,1,1,2 },
        { 0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0 },
    };

    public void LoadJson()
    {
        TextAsset asset = Resources.Load(Path.Combine("Maps", "map")) as TextAsset;
        Map m = JsonUtility.FromJson<Map>(asset.text);
        Debug.Log(m.name);
    }

    // Use this for initialization
    void Start () {
        generate_map();
        draw_map();
        LoadJson();

    }
	
    // draw images according to array
    void draw_map()
    {
        foreach (Tile b in map)
        {
            GameObject myTile = Instantiate(b.prefab, new Vector3(b.x, -b.y, 0), Quaternion.identity) as GameObject;
            myTile.name = b.type.ToString();
        }
    }

    // generate map object with tiles from 2D array win ints
    void generate_map()
    {
        for (int y = 0; y <= 15; y++)
        {
            for (int x = 0; x <= 15; x++)
            {
                Tile myTile = generate_Tile_from_hmap(hMap[x, y], y , x);
                map[x, y] = myTile;                
            }
        }
    }

    Tile generate_Tile_from_hmap(int number, int x, int y)
    {
        Tile myTile = new Tile();
        myTile = new Tile { prefab = map_Tiles[number], x = x, y = y, type = (Tile.tileType)number };
        


        return myTile;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
