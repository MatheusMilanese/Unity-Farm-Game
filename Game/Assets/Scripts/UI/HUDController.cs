using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [Header("Collectibles UI Bars")]
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    [Header("Tools UI")]
    [SerializeField] private Image[] toolsUI;
    [SerializeField] private Color selectColor;
    [SerializeField] private Color unselectColor;

    Player player;
    PlayerItens playerItens;

    private void Awake() {
        playerItens = FindObjectOfType<PlayerItens>();
        player = playerItens.GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start(){
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
    }

    // Update is called once per frame

    void Update(){
        waterUIBar.fillAmount = playerItens.CurrentWater / playerItens.waterLimit;
        woodUIBar.fillAmount = playerItens.TotalWood / playerItens.woodLimit;
        carrotUIBar.fillAmount = playerItens.TotalCarrots / playerItens.carrotLimit;

        for(int i = 0; i < toolsUI.Length; i++){
            toolsUI[i].color = i == player.HandlingObj ? selectColor : unselectColor;
        }
    }
}
