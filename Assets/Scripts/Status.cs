using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [Header("Max Stats")]
    [SerializeField] int maxHealth = 100;
    [SerializeField] int maxStamina = 100;
    [SerializeField] int maxHunger = 100;
    [SerializeField] int maxThirst = 100;

    [Header("Decrease rates")]
    [SerializeField] int thirstDecreaseRate = 1;
    [SerializeField] int hungerDecreaseRate = 1;

    [Header("Movement")]

    [SerializeField] int visionRange = 10;
    [SerializeField] int runSpeed = 20;
    [SerializeField] public int walkSpeed = 10;

    [Header("GameObject Reference")]

    [SerializeField] StatusBarBlock StatusBarBlock;
    public String objective = "Roam";
    public Vector3Int targetPos = new Vector3Int(0,0,0);

    private Animator animate;
    private int health;
    private int stamina;
    private int thirst;
    private int hunger;

    void Start()
    {
        thirst = maxThirst;
        hunger = maxHunger;
        animate = GetComponentInChildren<Animator>();
        StatusBarBlock.SetMaxValues(maxHealth, maxStamina, maxThirst, maxHunger);

        InvokeRepeating("statusUpdate", 1f, 1f); //will run statusUpdate function once every 1 sec
    }

    void statusUpdate() {
        thirst -= thirstDecreaseRate;
        hunger -= hungerDecreaseRate;
        StatusBarBlock.UpdateNeeds(thirst, hunger);
        print($"\tCurrent hunger:\t{StatusBarBlock.hungerBar.GetValue()}\n\t\tCurrent thirst:\t{StatusBarBlock.thirstBar.GetValue()}");
        if (StatusBarBlock.hungerBar.GetValue() == 0 || StatusBarBlock.thirstBar.GetValue() == 0) {Die();}
    }

    void Die()
    {
        animate.SetTrigger("dying");
    }

    void Update()
    {
        
    }
}
