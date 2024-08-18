using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int maxStamina = 100;
    [SerializeField] int maxHunger = 100;
    [SerializeField] int maxThirst = 100;
    [SerializeField] int visionRange = 10;
    [SerializeField] int runSpeed = 20;
    [SerializeField] int walkSpeed = 10;

    private int health;
    private int stamina;

    private Animator animate;
    
    public StatusBarBlock StatusBarBlock;

    void Start()
    {
        animate = GetComponentInChildren<Animator>();
        StatusBarBlock.healthBar.SetMaxValue(maxHealth);
        StatusBarBlock.staminaBar.SetMaxValue(maxStamina);
        StatusBarBlock.thirstBar.SetMaxValue(maxThirst);
        StatusBarBlock.hungerBar.SetMaxValue(maxHunger);

        InvokeRepeating("statusUpdate", 1f, 1f); //will run statusUpdate function once every 1 sec
    }

    void statusUpdate() {
        StatusBarBlock.UpdateNeeds();
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
