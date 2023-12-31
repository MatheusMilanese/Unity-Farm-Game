using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private int healthTree;

    [SerializeField] private GameObject woodPrefab;
    [SerializeField] private int totalWood;
    [SerializeField] private ParticleSystem particleLeafs;

    private bool isCut;

    private void OnHit(){
        healthTree--;
        anim.SetTrigger("hit");
        particleLeafs.Play();

        if(healthTree <= 0){
            for (int i = 0; i < totalWood; i++) {   
                Vector3 position = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
                Instantiate(woodPrefab, position, transform.rotation);
            }
            anim.SetTrigger("cut");
            isCut = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Axe") && !isCut){
            OnHit();
        }
    }
}
