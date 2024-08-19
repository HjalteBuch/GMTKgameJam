using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarBlock : MonoBehaviour
{
    public StatusBar healthBar;
    public StatusBar staminaBar;
    public StatusBar thirstBar;
    public StatusBar hungerBar;
    public void UpdateNeeds(int thirst, int hunger)
    {
        thirstBar.SetValue(thirst);
        hungerBar.SetValue(hunger);
    }

    public void SetMaxValues(int health, int stamina, int thirst, int hunger){
         healthBar.SetMaxValue(health);
        staminaBar.SetMaxValue(stamina);
         thirstBar.SetMaxValue(thirst);
         hungerBar.SetMaxValue(hunger);
    }
}
