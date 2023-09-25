using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] private GameObject actor;

    [Header("Dialogue")]
    private Sprite speakerSprite;
    private string sentece;

    public List<Senteces> dialogue = new List<Senteces>();
}

[System.Serializable]
public class Senteces {
    public string actorName;
    public Sprite profile;
    public Language sentence;
}

[System.Serializable]
public class Language {
    public string portuguese;
    public string english;
    public string spanish;
}
