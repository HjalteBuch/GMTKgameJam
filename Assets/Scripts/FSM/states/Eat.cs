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

        if(status.hunger >= status.maxHunger) {
            status.health = status.maxHealth;
            sc.ChangeState(new Chill());
        }
    }

    public override void OnExit() {
        status.SetAnimation("idle");
    }

    private void ReplenishHunger() {
        status.hunger += ConsumeResource();
    }

    private int ConsumeResource() {
        int amountConsumed = 0;
        switch (status.feedingStrategy)
        {
            case FeedingStrategy.grazer:
                Vector3Int tilePosition = mm.map.WorldToCell(status.transform.position);
                TileData tiledata = mm.GetTileData(tilePosition);
                if (tiledata.food) {
                    amountConsumed = 5;
                    tiledata.resource -= amountConsumed;
                    if (tiledata.resource <= 0) {
                        mm.map.SetTile(tilePosition, tiledata.spreadableTo);
                    }
                }
                else
                {
                    sc.ChangeState(new FindFood());
                }
                break;
            case FeedingStrategy.predetor:
                amountConsumed = 20;
                break;
        }

        return amountConsumed;
    }
}
