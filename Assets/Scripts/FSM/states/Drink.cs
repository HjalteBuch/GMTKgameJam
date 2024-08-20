using System;
using UnityEngine;

public class Drink : State
{
    protected override void OnEnter() {
        if (!mm.IsCurrentTileWater(status.transform.position)) {
            sc.ChangeState(new FindWater());
            return;
        }
        status.objective = "Drinking";
        status.SetAnimation("feeding");
    }

    private float time = 0.0f;
    private float everyXSeconds = 0.2f;

    public override void UpdateState() {
        time += Time.deltaTime;
        if (time > everyXSeconds) {
            time = 0.0f;
            ReplenishThirst();
        }

        if(status.thirst >= status.maxThirst) {
            sc.ChangeState(new Chill());
        }
    }

    public override void OnExit() {
        status.SetAnimation("idle");
    }

    private void ReplenishThirst() {
        status.thirst ++;
    }
}
