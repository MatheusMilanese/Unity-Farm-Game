using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int healthTree;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;

    private void OnHit(){
        healthTree--;
        anim.SetTrigger("hit");
        if(healthTree <= 0){
            for (int i = 0; i < totalWood; i++) {   
                Vector3 position = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                Instantiate(woodPrefab, position, transform.rotation);
            }
            anim.SetTrigger("cut");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Axe")){
            OnHit();
        }
    }
}
