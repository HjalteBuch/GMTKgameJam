using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePreviewOpacityChanger : MonoBehaviour
{

    private Tilemap tilemap;
    private float currentOpacity = 0.5f;
    private float opacityChange = 0.01f;
    private Color color = Color.white;

    void Start()
    {
        tilemap = this.GetComponent<Tilemap>();
    }

    void Update()
    {
        currentOpacity = currentOpacity + opacityChange;

        if (currentOpacity > 0.95 || currentOpacity < 0) {
            opacityChange = opacityChange*-1;
        }

        color.a = currentOpacity;
        tilemap.color = color;
    }
}
