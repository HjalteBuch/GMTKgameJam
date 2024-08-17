using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap map;

    [SerializeField]
    private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake() {
        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas) {
            foreach (var tile in tileData.tiles) {
                dataFromTiles.Add(tile, tileData);
            }
        }
    }


    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);

            float movementspeed = dataFromTiles[clickedTile].movementSpeed;
        }
    }

    public TileData GetTileData(Vector2 worldPosition) {
        Vector3Int gridPosition = map.WorldToCell(worldPosition);
        TileBase tile = map.GetTile(gridPosition);

        return dataFromTiles[tile];
    }

    public List<TileData> GetAllTileDataInRangeFromPosition(int range, Vector2 worldPosition) {
        Vector3Int gridPosition = map.WorldToCell(worldPosition);
        BoundsInt area = new BoundsInt(gridPosition.x-range, gridPosition.y-range, 0, range, range, 1);
        print("Area: " + area.ToString() + ", Position: " + gridPosition);
        TileBase[] tileArray = map.GetTilesBlock(area);

        List<TileData> tileDatas = new List<TileData>();

        foreach (TileBase tile in tileArray) {
            tileDatas.Add(dataFromTiles[tile]);
        }

        return tileDatas;
    }
}
