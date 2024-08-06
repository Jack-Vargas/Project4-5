using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Sanji : MonoBehaviour
{
    public bool Ready = false;
    public Dialogue dialogue;
    public DialogueManager script;
    public bool talkedToSanji;
    //public bool choiceAsk;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<Collider2D>().tag == "Player")
            Ready = true;
    }
    public void TriggerDialogue()
    {
        //choiceAsk = true;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    void OnTriggerExit2D()
    {
        Ready = false;
    }

    void Update()
    {
        if (Ready == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && script.talking == false)
            {
                TriggerDialogue();
                talkedToSanji = true;
            }
        }
    }
}
