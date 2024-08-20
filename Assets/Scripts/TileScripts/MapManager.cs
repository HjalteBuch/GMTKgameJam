using System;
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

    public bool IsCurrentTileFood(Vector3 pos) {
        Vector3Int pos3Int = map.WorldToCell(pos);
        return dataFromTiles[map.GetTile(pos3Int)].food;
    }

    public bool IsCurrentTileWater(Vector3 pos) {
        Vector3Int pos3Int = map.WorldToCell(pos);
        return dataFromTiles[map.GetTile(pos3Int)].water;
    }

    public Vector3 GetClosestTile(int range, Vector2 worldPosition, Predicate<TileData> predicate) {
        Vector3Int pointA = map.WorldToCell(worldPosition);
        BoundsInt area = new BoundsInt(pointA.x-(range/2), pointA.y-(range/2), 0, range, range, 1);

        Vector3 closestPoint = Vector3.zero;
        float shortestDistance = float.MaxValue;
        foreach (var pointB in area.allPositionsWithin) {
            if (predicate(dataFromTiles[map.GetTile(pointB)])) {
                if(Vector3.Distance(pointA, pointB) < shortestDistance) {
                    closestPoint = pointB;
                }
            }
        }

        return closestPoint;
    }
}
