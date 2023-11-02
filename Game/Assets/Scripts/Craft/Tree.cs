using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int healthTree;

    private void OnHit(){
        healthTree--;
        anim.SetTrigger("hit");
        if(healthTree <= 0){
            anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Axe")){
            OnHit();
        }
    }
}
