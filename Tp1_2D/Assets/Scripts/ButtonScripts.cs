using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueRef;

    public void NextButtonClick(){
        dialogueRef.NextDialogue();
    }

    public void NoButton(){
        dialogueRef.ChoiceDialogue();
    }
}
