using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBarBlock : MonoBehaviour
{
    public StatusBar healthBar;
    public StatusBar staminaBar;
    public StatusBar thirstBar;
    public StatusBar hungerBar;
    public void UpdateNeeds(){
        hungerBar.SetValue(hungerBar.GetValue()-1);
        thirstBar.SetValue(thirstBar.GetValue()-1);
    }
}
