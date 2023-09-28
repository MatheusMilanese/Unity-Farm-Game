using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerMask;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    public void ShowDialogue(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerMask);
        if(hit){
            Debug.Log("Colidiu pai");
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
