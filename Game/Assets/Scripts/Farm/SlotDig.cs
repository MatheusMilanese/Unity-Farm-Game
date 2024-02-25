using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDig : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Sprite spriteHole;
    [SerializeField] private Sprite spriteCarrot;
    [SerializeField] private SpriteRenderer spriteSlot;

    [SerializeField] private int digAmount = 5;
    [SerializeField] private float waterAmount = 5;

    private int currentDigAmount;
    private float currentWaterAmount;

    [SerializeField] private bool detectingWater;

    private bool dugHole;

    [SerializeField] private PlayerItens playerItens;

    private void Start() {
        playerItens = FindObjectOfType<PlayerItens>();
    }

    private void Update() {
        if(dugHole){
            if(detectingWater){
                currentWaterAmount += 0.01f;
            }
            if(currentWaterAmount >= waterAmount){
                spriteSlot.sprite = spriteCarrot;
                if(Input.GetKeyDown(KeyCode.E)){
                    playerItens.TotalCarrots++;
                    spriteSlot.sprite = null;
                    dugHole = false;
                    currentDigAmount = 0;
                    currentWaterAmount = 0;
                }
            }
        }
    }

    void OnHit(){
        currentDigAmount++;
        if(currentDigAmount >= digAmount){
            spriteSlot.sprite = spriteHole;
            dugHole = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Shovel")){
            OnHit();
        }
        if(other.CompareTag("Water")){
            detectingWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Water")){
            detectingWater = false;
        }
    }
}
