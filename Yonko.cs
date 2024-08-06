using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yonko : MonoBehaviour
{
    public bool Ready = false;
    public Dialogue dialogue;
    public DialogueManager script;
    public bool talkedToShanks;
    //public bool choiceAsk;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<Collider2D>().tag == "Player")
        {
            Ready = true;
        }   
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
                talkedToShanks = true;
            }
        }
    }
}
