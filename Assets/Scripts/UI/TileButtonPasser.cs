using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TileButtonPasser : MonoBehaviour
{
    [SerializeField] TileChanger tileChanger;
    [SerializeField] TileBase tileToPass;
    
    private Button button;

    void Start() {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick() 
    {
        tileChanger.SetPaintingTile(tileToPass);
    }

}
