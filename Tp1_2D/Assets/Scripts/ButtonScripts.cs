using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour
{
    [SerializeField] private Dialogue dialogueRef;

    public void ButtonClick()
    {
        if(dialogueRef.nextDialogue == false)
        {
            dialogueRef.nextDialogue = true;
        }
        else
        {
            dialogueRef.nextDialogue = false;
        }
    }
    
}
