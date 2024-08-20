using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindWater : State
{
    protected override void OnEnter() {
        status.objective = "Finding food";
        Vector3 water = mm.GetClosestTile(status.visionRange, status.transform.position, tile => tile.water);
        if (water == Vector3.zero) {
            // State should be changed to Roam, but Roam not implemented yet
            sc.ChangeState(new Chill());
            return;
        }

        status.targetPos = water;
        status.SetAnimation("walking");
    }

    public override void UpdateState() {
        Walk();
        if (Vector3.Distance(status.transform.position, status.targetPos) < 0.2f) {
            sc.ChangeState(new Drink());
        }
    }

    public override void OnExit() {
    }

    private void Walk() {
        Vector3 tp = status.targetPos;
        tp.z = sc.transform.position.z;
        sc.transform.position = Vector3.MoveTowards(sc.transform.position, tp, status.walkSpeed * Time.deltaTime);
    }
}
