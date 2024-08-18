using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TileChanger : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap hoverMap = null;
    [SerializeField] private Tilemap pathMap = null;
    [SerializeField] private Tile hoverTile = null;
    [SerializeField] private Tile paintingTile = null;


    private Vector3Int previousMousePos = new Vector3Int();

    void Start() {
        grid = gameObject.GetComponent<Grid>();
    }

    void Update() {
        // Mouse over -> highlight tile
        Vector3Int mousePos = GetMousePosition();
        if (!mousePos.Equals(previousMousePos)) {
            hoverMap.SetTile(previousMousePos, null);
            hoverMap.SetTile(mousePos, hoverTile);
            previousMousePos = mousePos;
        }

        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0)) {
            pathMap.SetTile(mousePos, paintingTile);
        }
    }

    Vector3Int GetMousePosition () {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}