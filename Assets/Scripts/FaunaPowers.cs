using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunaPowers : MonoBehaviour
{
    [SerializeField] int visionRange = 100;

    private MapManager mapManager;

    [SerializeField]
    private float moveTime;
    [SerializeField]
    private float baseSpeed;
    private float moveCounter;

    // Start is called before the first frame update
    void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
        moveCounter = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        moveCounter -= Time.deltaTime;

        if(moveCounter <= 0) {
            moveCounter = moveTime;
            float newRotation = Random.Range(0f, 360f);
            transform.rotation = Quaternion.Euler(0f, 0f, newRotation);
        }

        float adjustSpeed = mapManager.GetTileData(transform.position).movementSpeed * baseSpeed;
        transform.position += transform.up * Time.deltaTime * adjustSpeed;
    }

    private bool IsFoodNearby(){
        return false;
    }
}
