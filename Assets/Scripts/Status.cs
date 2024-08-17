using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int maxStamina = 100;
    [SerializeField] int maxHunger = 100;
    [SerializeField] int maxThirst = 100;
    [SerializeField] int visionRange = 100;
    [SerializeField] int runSpeed = 20;
    [SerializeField] int walkSpeed = 10;

    private int health;
    private int stamina;
    private int hunger;
    private int thirst;
    

    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        hunger = maxHunger;
        thirst = maxThirst;

        InvokeRepeating("statusUpdate", 1f, 1f); //will run statusUpdate function once every 1 sec
    }

    void statusUpdate() {
        hunger--;
        thirst--;
        if (hunger == 0 || thirst == 0) {Die();}
    }

    void Die()
    {
        
    }

    void Update()
    {
        
    }
}
