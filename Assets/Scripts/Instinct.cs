using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instinct : MonoBehaviour
{
    private MapManager mapManager;

    [SerializeField] private Status status;

    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
        InvokeRepeating("SetObjective", 1f, 1f);
    }

    public void SetObjective() {
        if (status.hunger < status.maxHunger / 2) {
            if (mapManager.IsCurrentTileFood(transform.position)){
                status.objective = Objective.Eat;
            }
            status.objective = Objective.FindFood;
        } else if (status.thirst < status.maxThirst / 2) {
            status.objective = Objective.FindWater;
        }
    }

    void Update()
    {
    }

}
