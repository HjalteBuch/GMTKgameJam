using System;
using UnityEngine;

public class Chill : State
{
    protected override void OnEnter() {
        status.objective = "Chilling";
    }

    protected override void UpdateState() {
        if (status.hunger < status.maxHunger / 2) {
            sc.ChangeState(new FindFood());
            return;
        } 
        if (status.thirst < status.maxThirst / 2) {
            sc.ChangeState(new FindWater());
            return;
        }
    }

    public override void OnExit() {
    }
}
