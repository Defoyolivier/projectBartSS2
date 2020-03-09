using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject DialogueBox;
    [SerializeField] private GameObject NextButtonGO;
    [SerializeField] private Button NextButton;
    public string KingDeText1 = "Testing stuff";
    private string currentText = "";
    public string fullText;
    public bool triggered = false;
    public List<string> TextDialogue;
    private int indexText = 0;
    private bool dialogue = true;
    private Coroutine DialogueCoRout;
    public bool NextDialogue = true;



    private void Start()
    {
        TextDialogue.Add("Kirby:\nEummmm... What are you doing?");
        TextDialogue.Add("King DeDeDe:\nMind your Own stuff kiddo!");
        TextDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        //NextButton.onClick.AddListener();


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

    public bool ButtonClick()
    {
        return NextDialogue;
    }


    IEnumerator ShowText(List<string> i_Text, GameObject dialogueBox)
    {
        for(int dialogue = 0; dialogue < 10; dialogue++)
        {

            if (!dialogueBox.activeSelf)
            {
                dialogueBox.SetActive(true);
                NextButtonGO.SetActive(true);
            }


            fullText = i_Text[indexText];
            
            if (ButtonClick())
            {
                for(int i = 0; i <= fullText.Length; i++)// typeWritter text
                {
                    currentText = fullText.Substring(0, i);
                    dialogueBox.GetComponentInChildren<Text>().text = currentText;

                    yield return new WaitForSeconds(0.1f);
            
                }
                NextDialogue = false;
            }


            indexText++;
        }


        
        yield return true;
    }


}
