using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaunaPowers : MonoBehaviour
{
    [SerializeField] int visionRange = 10;

    private MapManager mapManager;

    [SerializeField] private float moveTime;
    [SerializeField] private float baseSpeed;
    private float moveCounter;

    private String objective = "Roam";
    private Vector3Int goal;

    void Awake()
    {
        mapManager = FindObjectOfType<MapManager>();
        moveCounter = moveTime;
    }

    void Start() {
        goal =  new Vector3Int(0, 0, 0);
    }

    void Update()
    {
        Move();
    }

    void FindObjective()
    {
        moveCounter -= Time.deltaTime;

        if(moveCounter <= 0) {
            moveCounter = moveTime;
            goal = Goal();
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, (Vector3)goal, baseSpeed * Time.deltaTime);
    }

    private Vector3Int Goal(){
        Vector3Int? foodPos = mapManager.GetPositionOfHerbivoreFood(visionRange, transform.position);

        return foodPos ?? RandomGoal();
    }

    private Vector3Int RandomGoal () {
        var v = mapManager.GetCurrentTilePosition(transform.position);
        return new Vector3Int(UnityEngine.Random.Range(v.x-visionRange, v.y-visionRange), UnityEngine.Random.Range(v.x+visionRange, v.y+visionRange), 0);
    }

}
