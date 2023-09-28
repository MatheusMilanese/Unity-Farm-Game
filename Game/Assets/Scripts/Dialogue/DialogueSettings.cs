using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]
public class DialogueSettings : ScriptableObject
{
    [Header("Settings")]
    [SerializeField] private GameObject actor;

    [Header("Dialogue")]
    public Sprite speakerSprite;
    public string sentece;


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

#if UNITY_EDITOR
[CustomEditor(typeof(DialogueSettings))]
public class BuilderEditor : Editor {
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DialogueSettings ds = (DialogueSettings)target;

        Language l = new Language();
        l.portuguese = ds.sentece;

        Senteces s = new Senteces();
        s.profile = ds.speakerSprite;
        s.sentence = l;

        if(GUILayout.Button("Create Dialogue")){
            if(ds.sentece != ""){
                ds.dialogue.Add(s);
                ds.speakerSprite = null;
                ds.sentece = "";
            }
        }   
    }
}

#endif