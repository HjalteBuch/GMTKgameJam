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

    private Vector3Int goal;

    // Start is called before the first frame update
    void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
        moveCounter = moveTime;
    }

    void Start() {
        goal = Goal();
    }

    // Update is called once per frame
    void Update()
    {
        moveCounter -= Time.deltaTime;

        if(moveCounter <= 0) {
            moveCounter = moveTime;
            goal = Goal();
        }
        transform.position = Vector3.MoveTowards(transform.position, (Vector3)goal, baseSpeed * Time.deltaTime);
    }

    private Vector3Int Goal(){
        Vector3Int? foodPos = mapManager.GetPositionOfHerbivoreFood(visionRange, transform.position);

        return foodPos ?? RandomGoal();
    }

    private Vector3Int RandomGoal () {
        var v = mapManager.GetCurrentTilePosition(transform.position);
        return new Vector3Int(Random.Range(v.x-visionRange, v.y-visionRange), Random.Range(v.x+visionRange, v.y+visionRange), 0);
    }

}
