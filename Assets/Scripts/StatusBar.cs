using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] Slider staminaBar;
    [SerializeField] Slider thirstBar;
    [SerializeField] Slider hungerBar;
    [SerializeField] GameObject creature;

    public Health creatureHealth;

    private void Start();
    {
        creatureHealth = creature.GetComponent<Health>();
        healthBar = GetComponentIn<Slider>();
        staminaBar = GetComponent<Slider>();
        thirstBar = GetComponent<Slider>();
        hungerBar = GetComponent<Slider>();

        healthBar.maxValue = creatureHealth.maxHealth;
        healthBar.value = creatureHealth.maxHealth;
    }
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}
