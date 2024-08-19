using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFood : State
{
    protected override void OnEnter() {
        status.objective = "Finding food";
        List<Vector3Int> pointsWithFood = mm.GetPositionsWithNearbyFood(status.visionRange, status.transform.position);
        if (pointsWithFood.Count == 0) {
            // State should be changed to Roam, but Roam not implemented yet
            sc.ChangeState(new Chill());
        } else {
            status.targetPos = GetNearestFoodPosition(pointsWithFood, status.transform.position);
            status.SetAnimation("walking");
        }
    }

    public override void UpdateState() {
        Walk();
        if (Vector3.Distance(status.transform.position, status.targetPos) < 0.2f) {
            sc.ChangeState(new Eat());
        }
    }

    public override void OnExit() {
    }

    private Vector3 GetNearestFoodPosition(List<Vector3Int> pointsWithFood, Vector3 currentPoint) {
        Vector3Int closestPoint = pointsWithFood[0];
        float shortestDistance = float.MaxValue;
        foreach (var point in pointsWithFood) {
            float thisDistance = Vector3.Distance(point, currentPoint);
            if (thisDistance < shortestDistance) {
                closestPoint = point;
            }
        }
        return closestPoint;
    }

    private void Walk() {
        Vector3 tp = status.targetPos;
        tp.z = sc.transform.position.z;
        sc.transform.position = Vector3.MoveTowards(sc.transform.position, tp, status.walkSpeed * Time.deltaTime);
    }
}
