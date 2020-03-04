using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private GameObject NextButton;
    public string KingDeText1 = "Testing stuff";
    private string currentText = "";
    public string fullText;
    public bool triggered = false;
    public List<string> TextDialogue;
    private int indexText = 0;
    private bool dialogue = true;
    private Coroutine DialogueCoRout;



    private void Start()
    {
        TextDialogue.Add("Eummmm... What are you doing?");
        TextDialogue.Add("Mind your Own stuff kiddo!");
        TextDialogue.Add("");


    }

    private void Update()
    {
        if (triggered)
        {
            if (DialogueCoRout == null)
            {
                DialogueCoRout = StartCoroutine(ShowText(TextDialogue, DialogueBox));


            }
        }
    }


    IEnumerator ShowText(List<string> i_Text, GameObject dialogueBox)
    {
        if (!dialogueBox.activeSelf)
        {
            dialogueBox.SetActive(true);
            NextButton.SetActive(true);
        }


        fullText = i_Text[indexText];

        for(int i = 0; i <= fullText.Length; i++)// typeWritter text
        {
            currentText = fullText.Substring(0, i);
            dialogueBox.GetComponentInChildren<Text>().text = currentText;

            yield return new WaitForSeconds(0.1f);
            
        }

        
        


        
        yield return true;
    }


}
