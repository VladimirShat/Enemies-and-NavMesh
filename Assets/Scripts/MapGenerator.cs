using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public int columnCount;
    public int rowCount;

    private GameObject currentTile;

    void Start()
    {
        LoadMap();
    }

    void Update()
    {
        //recreate map
        if (Input.GetMouseButtonDown(1))
        {
            foreach (Transform child in transform)
                Destroy(child.gameObject);
            LoadMap();
        }
    }

    void LoadMap()
    {
        for (int x = 0; x < rowCount; x++)
        {
            for (int z = 0; z < columnCount; z++)
            {
                currentTile = tiles[Random.Range(0, tiles.Length)];
                Vector3 halfTileScale = currentTile.transform.localScale / 2;
                Vector3 currentTilePosition = new Vector3(transform.localPosition.x + x + halfTileScale.x, transform.localPosition.y, transform.localPosition.z + z + halfTileScale.z);

                GameObject tileObj = Instantiate(currentTile, currentTilePosition, Quaternion.identity);
                tileObj.transform.parent = transform;
            }
        }
    }
}
