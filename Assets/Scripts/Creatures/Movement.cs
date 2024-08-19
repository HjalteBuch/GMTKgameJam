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
            case "food":
                var pos = transform.position;
                List<Vector3Int> foodNearby = mapManager.GetPositionsWithNearbyFood(status.visionRange, pos);
                if (foodNearby.Count == 0) {
                    print("No food nearby");
                    break;
                }
                status.targetPos = GetClosestPosition(foodNearby, pos);
                break;
            case "water":
                break;
            case "roam":
                break;
            default:
                break;
        }
    }

    void Update()
    {
        switch (status.objective) {
            case "food":
                if (Vector3.Distance(transform.position, status.targetPos) > 0.2f) {
                    status.SetAnimation("walking");
                    Walk();
                } else {
                    if (mapManager.IsCurrentTileFood(transform.position)){
                        status.objective = "eat";
                    }
                }
                break;
            case "eat":
                status.SetAnimation("feeding");
                break;
            case "water":
                break;
            case "roam":
                break;
            case "chill":
                break;
            default:
                break;
        }

        if (transform.position == status.targetPos) {
            status.SetAnimation("idle");
        }
    }


    private Vector3 GetClosestPosition(List<Vector3Int> listOfPositions, Vector3 targetPos) {
        Vector3 closestPos = listOfPositions[0];
        float distance = float.MaxValue;
        foreach (Vector3Int pos in listOfPositions) {
            float newDistance = Vector3.Distance(pos, targetPos); 
            if (newDistance < distance) {
                closestPos = pos;
                distance = newDistance;
            }
        }
        closestPos.x += 0.5f;
        closestPos.y += 0.5f;
        return closestPos;
    }
}
