using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    public float movementSpeed;
    public bool herbivoreFood;
    public bool carnivoreFood;
    public bool water;
}
