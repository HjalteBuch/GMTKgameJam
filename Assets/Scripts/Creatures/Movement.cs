using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    [SerializeField] public Status status;
    private MapManager mapManager;

    void Walk()
    {
        Vector3 tp = status.targetPos;
        tp.z = transform.position.z;
        tp.x += 0.5f;
        tp.y += 0.5f;
        transform.position = Vector3.MoveTowards(transform.position, tp, status.walkSpeed * Time.deltaTime);
    }

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        InvokeRepeating("SetTargetPos", 1f, 1f);
    }

    private void SetTargetPos()
    {
        switch (status.objective) {
            case Objective.FindFood:
                var pos = transform.position;
                List<Vector3Int> foodNearby = mapManager.GetPositionsWithNearbyFood(status.visionRange, pos);
                if (foodNearby.Count == 0) {
                    print("No food nearby");
                    break;
                }
                status.targetPos = GetClosestPosition(foodNearby, pos);
                break;
            case Objective.FindWater:
                break;
            case Objective.Roam:
                break;
            case Objective.Chill:
                break;
            default:
                break;
        }
    }

    void Update()
    {
        Walk();
    }


    private Vector3Int GetClosestPosition(List<Vector3Int> listOfPositions, Vector3 targetPos) {
        Vector3Int closestPos = listOfPositions[0];
        float distance = float.MaxValue;
        foreach (Vector3Int pos in listOfPositions) {
            float newDistance = Vector3.Distance(pos, targetPos); 
            if (newDistance < distance) {
                closestPos = pos;
                distance = newDistance;
            }
        }
        return closestPos;
    }
}
