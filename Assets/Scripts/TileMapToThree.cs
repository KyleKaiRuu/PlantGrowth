using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapToThree : MonoBehaviour
{
    public Tilemap tileMap;

    public Grid localGrid;
    public GameObject[] myTileCatalogue;

    private void Start()
    {
        for (int x = 0; x < localGrid.cellSize.x; x++)
        {
            for (int y = 0; y < localGrid.cellSize.y; y++)
            {
                Dictionary<TileBase, GameObject> myTileToPrefabDict = new Dictionary<TileBase, GameObject>();
                GameObject tmp = Instantiate(myTileToPrefabDict[tileMap.GetTile(new Vector3Int(x, y, 0))], localGrid.CellToWorld(new Vector3Int(x, y, 0)), Quaternion.identity);
            }
        }
    }

    GameObject SetTile(int x, int y, int idx)
    {
        idx = 0;
        //int rFloor = 0;

        //if (myTileCatalogue[idx].floorPrefab.Length > 1)
        //    rFloor = Random.Range(0, myTileCatalogue[idx].floorPrefab.Length);
        //GameObject tmp = Instantiate(myTileCatalogue[idx].floorPrefab[rFloor]);


        //tmp.transform.position = localGrid.CellToWorld(new Vector3Int(x, y, 0));
        //if (myTileCatalogue[idx].randomRotaionAllowed)
        //{
        //    int r = Random.Range(0, 4);
        //    tmp.transform.Rotate(new Vector3(0, 0, r * 90));
        //}
        //return tmp;
        return new GameObject();
    }
}
