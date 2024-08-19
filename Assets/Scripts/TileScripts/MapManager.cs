using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    public Tilemap map;

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
            print(mousePosition);
        }
    }

    public Vector3Int GetCurrentTilePosition(Vector3 worldPosition) {
        return map.WorldToCell(worldPosition);
    }

    public TileData GetTileData(Vector2 worldPosition) {
        Vector3Int gridPosition = map.WorldToCell(worldPosition);
        TileBase tile = map.GetTile(gridPosition);

        return dataFromTiles[tile];
    }

    public List<Vector3Int> GetPositionsWithNearbyFood(int range, Vector2 worldPosition) {
        Vector3Int gridPosition = map.WorldToCell(worldPosition);
        BoundsInt area = new BoundsInt(gridPosition.x-(range/2), gridPosition.y-(range/2), 0, range, range, 1);

        List<Vector3Int> positionsWithFood = new List<Vector3Int>();
        foreach (var point in area.allPositionsWithin) {
            if (dataFromTiles[map.GetTile(point)].Food) {
                positionsWithFood.Add(point);
            }
        }

        return positionsWithFood;
    }

    public bool IsCurrentTileFood(Vector3 pos) {
        Vector3Int pos3Int = map.WorldToCell(pos);
        return dataFromTiles[map.GetTile(pos3Int)].Food;
    }
}
