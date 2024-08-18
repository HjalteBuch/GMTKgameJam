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
        status.targetPos.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, status.targetPos, status.walkSpeed * Time.deltaTime);
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
                print("Find Food");
                var pos = transform.position;
                List<Vector3Int> foodNearby = mapManager.GetPositionsWithNearbyFood(status.visionRange, pos);
                if (foodNearby.Count == 0) {
                    print("No food nearby");
                    break;
                }
                status.targetPos = GetClosestPosition(foodNearby, pos);
                break;
            case Objective.FindWater:
                print("Find Water");
                break;
            case Objective.Roam:
                print("Roam");
                break;
            case Objective.Chill:
                print("Chill");
                break;
            default:
                print("default");
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
            if (Vector3.Distance(pos, targetPos) < distance) {
                closestPos = pos;
            }
        }
        return closestPos;
    }
}
