using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenuClose : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick() 
    {
        menu.SetActive(false);
    }
}
