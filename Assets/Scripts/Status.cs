using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Objective {
    Roam,
    FindFood,
    FindWater,
    Chill,
}

public class Status : MonoBehaviour
{
    [Header("Max Stats")]
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int maxStamina = 100;
    [SerializeField] public int maxHunger = 100;
    [SerializeField] public int maxThirst = 100;

    [Header("Decrease rates")]
    [SerializeField] int thirstDecreaseRate = 1;
    [SerializeField] int hungerDecreaseRate = 1;

    [Header("Movement")]

    [SerializeField] public int visionRange = 10;
    [SerializeField] public int runSpeed = 20;
    [SerializeField] public int walkSpeed = 10;

    [Header("GameObject Reference")]
    [SerializeField] StatusBarBlock StatusBarBlock;

    public Objective objective;
    public Vector3 targetPos;

    private Animator animate;
    public int health;
    public int stamina;
    public int thirst;
    public int hunger;

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
        if (hunger == 0 || thirst == 0) { Die(); }
    }

    void Die()
    {
        animate.SetTrigger("dying");
    }

    void Update()
    {
        
    }
}
