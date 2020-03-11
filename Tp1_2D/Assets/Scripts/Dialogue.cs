using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject nextButtonGO;
    [SerializeField] private Button nextButton;
    public string kingDeText1 = "Testing stuff";
    private string currentText = "";
    public string fullText;
    public bool triggered = false;
    public List<string> textDialogue;
    private int indexText = 0;
    private bool dialogue = true;
    private Coroutine dialogueCoRout;
    public bool nextDialogue = false;
    private bool firstDialogue = true;



    private void Start()
    {
        textDialogue.Add("Kirby:\nEummmm... What are you doing?");
        textDialogue.Add("King DeDeDe:\nMind your Own stuff kiddo!");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        textDialogue.Add("Kirby:\nREEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
        //NextButton.onClick.AddListener();


    }

    private void Update()
    {
        CheckTrigger();
    }

    private void CheckTrigger()
    {
        if (triggered)
        {
            if (dialogueCoRout == null)
            {
                if (nextDialogue)
                {
                    StopCoroutine(dialogueCoRout);
                    indexText++;
                    nextDialogue = false;
                }
                else
                {
                    dialogueCoRout = StartCoroutine(ShowText(textDialogue, dialogueBox, indexText));

                }

            }

        }
    }


    IEnumerator ShowText(List<string> i_Text, GameObject dialogueBox, int indexText)
    {


        if (!dialogueBox.activeSelf)
        {
            dialogueBox.SetActive(true);
            nextButtonGO.SetActive(true);
        }
  
        fullText = i_Text[indexText];
        for (int i = 0; i <= fullText.Length; i++)// typeWritter text
        {
            currentText = fullText.Substring(0, i);
            dialogueBox.GetComponentInChildren<Text>().text = currentText;

            yield return new WaitForSeconds(0.1f);
            
        }

        

        yield return true;
    }


}
