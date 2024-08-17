using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunaPowers : MonoBehaviour
{
    [SerializeField] int visionRange = 10;

    private MapManager mapManager;

    [SerializeField]
    private float moveTime;
    [SerializeField]
    private float baseSpeed;
    private float moveCounter;

    private Vector3Int? goal;

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
            SetGoal();
            moveCounter = moveTime;
            float newRotation = Random.Range(0f, 360f);
            transform.rotation = Quaternion.Euler(0f, 0f, newRotation);

        }

        float adjustSpeed = mapManager.GetTileData(transform.position).movementSpeed * baseSpeed;
        transform.position += transform.up * Time.deltaTime * adjustSpeed;
    }

    private void SetGoal(){
        Vector3Int? foodPos = mapManager.GetPositionOfHerbivoreFood(visionRange, transform.position);
        if (foodPos == null) {
            var rand = Random.Range(-visionRange, visionRange);
            var newPos = Vector3.Lerp(transform.position, rand, Time.deltaTime * baseSpeed);
            return;
        }
        goal = foodPos;
        // Move the animal towards the foodPos
    }

}
