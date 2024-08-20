using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFood : State
{
    protected override void OnEnter() {
        status.objective = "Finding food";
        Vector3 food = Vector3.zero;
        switch (status.feedingStrategy) {
            case FeedingStrategy.grazer:
                food = mm.GetClosestTile(status.visionRange, status.transform.position, tile => tile.food);
                if (food == Vector3.zero) {
                    // State should be changed to Roam, but Roam not implemented yet
                    sc.ChangeState(new Chill());
                    break;
                }
                status.targetPos = food;
                status.SetAnimation("walking");
                break;
            case FeedingStrategy.predetor:
                break;
        }
    }

    protected override void UpdateState() {
        Walk();
        if (Vector3.Distance(status.transform.position, status.targetPos) < 0.2f) {
            sc.ChangeState(new Eat());
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
