using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class TileChanger : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap hoverMap = null;
    [SerializeField] private Tilemap previewMap = null;
    [SerializeField] private Tilemap biomeMap = null;
    [SerializeField] private Tile hoverTile = null;
    
    private TileBase paintingTile = null;
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

            previewMap.SetTile(previousMousePos, null);
            previewMap.SetTile(mousePos, paintingTile);
            
            previousMousePos = mousePos;
        }

        // Left mouse click -> add path tile
        if (Input.GetMouseButton(0) && paintingTile != null) {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                biomeMap.SetTile(mousePos, paintingTile);
            }
        }
    }

    public void SetPaintingTile (TileBase newTile) {
        paintingTile = newTile;
    }

    Vector3Int GetMousePosition () {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}