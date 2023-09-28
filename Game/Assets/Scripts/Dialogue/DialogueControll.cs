using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControll : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueBox;
    public Image speakerSprite;
    public TextMeshPro speechText;
    public TextMeshPro actorNameText;

    [Header("Settings")]
    public float textSpeed;

    //Variáveis de controle
    private bool _isShowing;
    private int _index;
    private string[] _sentences;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence(){
        foreach(char letter in _sentences[_index]){
            speechText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextSentence(){

    }

    public void Speech(string[] txt){
        if(!_isShowing){
            dialogueBox.SetActive(true);
            _sentences = txt;
            StartCoroutine(TypeSentence());
            _isShowing = true;
        }
    }
}
