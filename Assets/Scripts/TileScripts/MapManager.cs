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

    private readonly Vector3Int[] neighbourPositions = {
            Vector3Int.up,
            Vector3Int.right,
            Vector3Int.down,
            Vector3Int.left,
        };

    private void Awake() {
        dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas) {
            foreach (var tile in tileData.tiles) {
                dataFromTiles.Add(tile, tileData);
            }
        }

        InvokeRepeating("TileSpread", 1f, 1f);
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

    public TileData GetTileData(Vector3Int worldPosition) {
        TileBase tile = map.GetTile(worldPosition);
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

    private void TileSpread() {
        foreach (var position in map.cellBounds.allPositionsWithin) {
            TileBase spreadableTile = GetTileData(position).spreadableTo;
            bool originTileCannotSpread = spreadableTile == null;
            if (originTileCannotSpread) {
                continue;
            }
            
            var neighbours = GetNeighbors(position);
            foreach (var neighbouringTile in neighbours)
            {
                bool neighbourIsSpreadableTo = GetTileData(neighbouringTile).tiles[0] == spreadableTile;
                if (neighbourIsSpreadableTo)
                {
                    float randomValue = UnityEngine.Random.value;
                    if (randomValue < .005f) {
                        map.SetTile(neighbouringTile, GetTileData(position).tiles[0]);
                    }
                }
            }
        }
    }

    private List<Vector3Int> GetNeighbors(Vector3Int tilePosition) {
        var neighbouringTiles = new List<Vector3Int>();
        foreach(var neighbourPosition in neighbourPositions) {
            var position = tilePosition + neighbourPosition;

            if(map.HasTile(position))
            {
                neighbouringTiles.Add(position);
            }
        }
        return neighbouringTiles;
    }

    internal void GetTileData(Vector3 position)
    {
        throw new NotImplementedException();
    }
}
