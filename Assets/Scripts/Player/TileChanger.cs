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
    private AudioClip[] placmentSoundEffect;
    private Vector3Int previousMousePos = new Vector3Int();
    private Vector3Int mousePos = new Vector3Int();


    void Start() {
        grid = gameObject.GetComponent<Grid>();
    }

    void Update() {
        mousePos = GetMousePosition();

        if (!mousePos.Equals(previousMousePos)) {
            createPreview();
        }

        if (Input.GetMouseButton(0) ) {
            PaintTile();
        }
    }

    void createPreview()
    {
        hoverMap.SetTile(previousMousePos, null);
        hoverMap.SetTile(mousePos, hoverTile);

        previewMap.SetTile(previousMousePos, null);
        previewMap.SetTile(mousePos, paintingTile);
        
        previousMousePos = mousePos;
    }

    void PaintTile() 
    {
        if (paintingTile == null) {return;}
        if (EventSystem.current.IsPointerOverGameObject()) {return;}
        if (biomeMap.GetTile(mousePos) == paintingTile) {return;} 

        biomeMap.SetTile(mousePos, paintingTile);
        SFXManager.instance.PlayRandomSFXClip(placmentSoundEffect, mousePos, 1f);
    }

    public void SetPaintingTile (TileBase newTile, AudioClip[] tilePlacmentSound) {
        paintingTile = newTile;
        placmentSoundEffect = tilePlacmentSound;
    }

    Vector3Int GetMousePosition () {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }
}