using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public int columns;
    public int rows;
    private int currentTile = 0;

    void Start()
    {
        LoadMap();
    }

    void Update()
    {
        //recreate new map
        if (Input.GetMouseButtonDown(1))
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);
            LoadMap();
        }
    }

    void LoadMap()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int z = 0; z < columns; z++)
            {
                currentTile = Random.Range(0, tiles.Length);
                GameObject tileObj;
                tileObj = Instantiate(tiles[currentTile], new Vector3(x + transform.localPosition.x + tiles[currentTile].transform.localScale.x / 2, transform.localPosition.y, z + transform.localPosition.z + tiles[currentTile].transform.localScale.z / 2), Quaternion.identity);
                tileObj.transform.parent = transform;
            }
        }
    }
}
