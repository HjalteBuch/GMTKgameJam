using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instinct : MonoBehaviour
{
    private MapManager mapManager;

    [SerializeField] private Status status;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        print(mapManager);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = mapManager.map.WorldToCell(mousePosition);
            status.targetPos = gridPosition;
        }
        
    }
}
