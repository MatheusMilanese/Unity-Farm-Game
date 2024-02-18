using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotDig : MonoBehaviour
{
    private int currentDigAmount;
    
    [SerializeField] private int digAmount;
    [SerializeField] private Sprite spriteHole;
    [SerializeField] private Sprite spriteCarrot;
    [SerializeField] private SpriteRenderer spriteSlot;

    void OnHit(){
        currentDigAmount++;
        if(currentDigAmount >= digAmount){
            spriteSlot.sprite = spriteHole;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Shovel")){
            OnHit();
        }
    }
}
