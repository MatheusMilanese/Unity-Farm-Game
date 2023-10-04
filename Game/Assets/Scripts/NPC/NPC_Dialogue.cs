using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerMask;

    private bool playerHit;
    public DialogueSettings dialogue;
    private List<string> sentences = new List<string>();
    
    void Start()
    {
        GetNPCInfo();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && playerHit){
            DialogueController.instance.Speech(sentences.ToArray());
        }
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    public void GetNPCInfo(){
        for(int i = 0; i < dialogue.dialogues.Count; i ++){
            switch(DialogueController.instance.language){
                case DialogueController.idiom.pt:
                    sentences.Add(dialogue.dialogues[i].sentence.portuguese);
                    break;
                case DialogueController.idiom.eng:
                    sentences.Add(dialogue.dialogues[i].sentence.english);
                    break;
                case DialogueController.idiom.spa:
                    sentences.Add(dialogue.dialogues[i].sentence.spanish);
                    break;
            }
        }
    }

    public void ShowDialogue(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerMask);
        if(hit){
            
            playerHit = true;
        }
        else{
            playerHit = false;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
