using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : State
{
    protected override void OnEnter() {
        status.SetAnimation("running");
        RandomFleelocation();
    }

    float secondsToFlee = 5f;

    protected override void UpdateState() {
        Run();
        if (Vector2.Distance(status.transform.position, status.targetPos) < 0.2f) {
            RandomFleelocation();
        }
        if (secondsToFlee <= 0f) {
            sc.ChangeState(new Chill());
        }
        secondsToFlee -= Time.deltaTime;
    }

    public override void OnExit() {
        status.SetAnimation("idle");
    }

    private void Run() {
        Vector3 tp = status.targetPos;
        tp.z = sc.transform.position.z;
        sc.transform.position = Vector3.MoveTowards(sc.transform.position, tp, status.runSpeed * Time.deltaTime);
    }
    private void RandomFleelocation() {
        float distanceToRun = 5f;
        Vector3 newTarget = status.targetPos;
        newTarget.x = Random.Range(newTarget.x - distanceToRun, newTarget.x + distanceToRun);
        newTarget.y = Random.Range(newTarget.y - distanceToRun, newTarget.y + distanceToRun);
        status.targetPos = newTarget;
    }
}
