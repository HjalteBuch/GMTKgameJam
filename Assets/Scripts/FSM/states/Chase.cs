using System;
using UnityEngine;

public class Chase : State
{
    protected override void OnEnter() {
        status.objective = "Chasing prey";
    }

    protected override void UpdateState() {
        if (Vector2.Distance(status.transform.position, status.targetPos) < 0.1f) {
            status.DealDamage();
        }
        FindLocationOfPrey();
        Walk();
    }

    public override void OnExit() {
    }

    private void Walk() {
        Vector3 tp = status.targetPos;
        tp.z = sc.transform.position.z;
        sc.transform.position = Vector3.MoveTowards(sc.transform.position, tp, status.walkSpeed * Time.deltaTime);
    }

    private void FindLocationOfPrey() {
        status.targetPos = status.activePrey.transform.position;
    }
}
