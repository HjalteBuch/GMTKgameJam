using System;
using UnityEngine;

public class Chill : State
{
    protected override void OnEnter() {
        status.objective = "Chilling";
    }

    public override void UpdateState() {
        if (status.hunger < status.maxHunger / 2) {
            sc.ChangeState(new FindFood());
        }
    }

    public override void OnExit() {
    }
}
