using System;
using UnityEngine;

public class Eat : State
{
    protected override void OnEnter() {
        if (!mm.IsCurrentTileFood(status.transform.position)) {
            sc.ChangeState(new FindFood());
            return;
        }
        status.objective = "Eating";
        status.SetAnimation("feeding");
    }

    private float time = 0.0f;
    private float everyXSeconds = 0.2f;

    public override void UpdateState() {
        time += Time.deltaTime;
        if (time > everyXSeconds) {
            time = 0.0f;
            ReplenishHunger();
        }
    }

    public override void OnExit() {
    }

    private void ReplenishHunger() {
        status.hunger ++;
    }
}
