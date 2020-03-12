using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject nextButtonGO;
    [SerializeField] private GameObject NoButtonGO;
    [SerializeField] private GameObject kingDeGO;
    [SerializeField] private GameObject triggerzone;
    [SerializeField] private Button nextButton;
    [SerializeField] private Animator kingDeAnimator;
    [SerializeField] private Text textYes;

    [SerializeField] private AudioSource kingDeSoundText;
    [SerializeField] private AudioSource kirbySoundText;
    [SerializeField] private AudioSource encounter;


    public List<string> textDialogueBase;
    public List<string> textDialogueNo;

    public string kingDeText1 = "Testing stuff";
    private string currentText = "";
    public string fullText;
    private int indexTextBase = 0;
    private int indexTextNo = 0;
    private bool dialogue = true;
    private bool textTurn = true;
    private bool noDIalogue = false;
    private Coroutine dialogueCoRout;
    public bool triggered = false;



    private void Start(){
        textDialogueBase.Add("Kirby:\nEummmm... What are you doing?");
        textDialogueBase.Add("King DeDeDe:\nMind your own stuff kiddo!");
        textDialogueBase.Add("Kirby:\nWow why are you so rude????");
        textDialogueBase.Add("King DeDeDe:\ndid you forget we are nemesis???");
        textDialogueBase.Add("Kirby:\noh... yeah i forgot...");
        textDialogueBase.Add("King DeDeDe:\nWait.. why are we nemesis... i dont remember.. wanna be friend?");
        textDialogueBase.Add("King DeDeDe:\nNice i need to do stuff for now but ill wait for you later. cya!");
        textDialogueBase.Add("Kirby:\n allrighty! lets go shopping!");
        textDialogueBase.Add("");

        textDialogueNo.Add("King DeDeDe:\nI was asking nicely but since you dont care im gonna mop the floor with you in the next game!");
        textDialogueNo.Add("Kirby:\nTry me im gonna put you to sleep!");
        textDialogueNo.Add("King DeDeDe:\nIt's On!");
    }

    private void Update(){
        CheckTrigger();
    }

    private void CheckTrigger(){
        if (triggered){
            kingDeAnimator.SetTrigger("dialogue started");
            if (dialogueCoRout == null){
                encounter.Play();
                dialogueCoRout = StartCoroutine(ShowText(textDialogueBase, dialogueBox, indexTextBase));
            }
        }
    }

    public void NextDialogue(){
        if (!noDIalogue){

            if(indexTextBase < 7){
                StopCoroutine(dialogueCoRout);
                dialogueCoRout = StartCoroutine(ShowText(textDialogueBase, dialogueBox, indexTextBase));
                indexTextBase++;
            }
            else{
                StopAllCoroutines();
                triggerzone.SetActive(false);
                dialogueBox.SetActive(false);
                kingDeGO.SetActive(false);
                triggered = false;
                kingDeSoundText.Stop();
            }

            if(indexTextBase == 6){
                NoButtonGO.SetActive(true);
                textYes.text = "YES!!";
            }
            else{
                NoButtonGO.SetActive(false);
                textYes.text = "Next >>>";
            }
        }
        else{
            if (indexTextNo < 3){
                StopCoroutine(dialogueCoRout);
                dialogueCoRout = StartCoroutine(ShowText(textDialogueNo, dialogueBox, indexTextNo));
                indexTextNo++;
            }
            else{
                StopAllCoroutines();
                triggerzone.SetActive(false);
                dialogueBox.SetActive(false);
                kingDeGO.SetActive(false);
                triggered = false;
                kingDeSoundText.Stop();
            }
        }
    }

    public void ChoiceDialogue(){
        NoButtonGO.SetActive(false);
        noDIalogue = true;
        NextDialogue();
    }

    IEnumerator ShowText(List<string> i_Text, GameObject dialogueBox, int indexText){
        
        if (!dialogueBox.activeSelf){
            dialogueBox.SetActive(true);
            nextButtonGO.SetActive(true);
        }
 
        fullText = i_Text[indexText];
        if (textTurn){
            kingDeSoundText.Stop();
            kirbySoundText.Play();
            textTurn = false;
        }
        else{
            kirbySoundText.Stop();
            kingDeSoundText.Play();
            textTurn = true;
        }
        for (int i = 0; i <= fullText.Length; i++){// typeWritter text
            currentText = fullText.Substring(0, i);
            dialogueBox.GetComponentInChildren<Text>().text = currentText;

            yield return new WaitForSeconds(0.05f);
        }
        yield return true;
    }
}
