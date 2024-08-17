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
    [SerializeField] int visionRange = 100;
    [SerializeField] int runSpeed = 20;
    [SerializeField] int walkSpeed = 10;

    private int health;
    private int stamina;
    private int hunger;
    private int thirst;
    
    private Slider healthBar;
    private Slider staminaBar;
    private Slider thirstBar;
    private Slider hungerBar;

    void Start()
    {
        health = maxHealth;
        stamina = maxStamina;
        hunger = maxHunger;
        thirst = maxThirst;

        healthBar = gameobject.GetComponentInChildren<Transform>().Find("healthBar").GetComponent<Slider>();
        staminaBar = gameobject.GetComponentInChildren<Transform>().Find("staminaBar").GetComponent<Slider>();
        thirstBar = gameobject.GetComponentInChildren<Transform>().Find("thirstBar").GetComponent<Slider>();
        hungerBar = gameobject.GetComponentInChildren<Transform>().Find("hungerBar").GetComponent<Slider>();

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
