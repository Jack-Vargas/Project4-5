using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public Text nameText;
    public Text dialogueText;
    public Behaviour PlayerMove;
    public bool talking;
    public GameObject TextBuble;
    public GameObject choiceButtons;
    public bool Choice;
    public bool done;

    //public Animator animator;

    private Queue<string> sentences;
    private string[] sentencesA;
    private string[] sentencesB;

    // Start is called before the first frame update
    void Start()
    {
        talking = false;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Choice = false;
        PlayerMove.enabled = false;
        talking = true;
        TextBuble.SetActive(true);
        Choice = dialogue.choice;

        sentencesA = dialogue.sentencesA;
        sentencesB = dialogue.sentencesB;

    //animator.SetBool("IsOpen", true); 

    //nameText.text = dialogue.name;

    sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 1)
        {
            done = true;
            if (Choice == true)
            {
                choiceButtons.SetActive(true);
                Choice = false;
            }
        }

        if (sentences.Count == 0 && Choice == false)
        {
            if (done == true)
            {
                StartCoroutine(WaitToStop());
            }
            EndDialogue();
            return;  
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void ChoiceA()
    {
        Choice = false;
        choiceButtons.SetActive(false);
        foreach (string sentence in sentencesA)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void ChoiceB()
    {
        Choice = false;
        choiceButtons.SetActive(false);
        foreach (string sentence in sentencesB)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    void EndDialogue()
    {
            TextBuble.SetActive(false);
            //animator.SetBool("IsOpen", false);
            PlayerMove.enabled = true;
            choiceButtons.SetActive(false);
            done = false;
    }

    public IEnumerator WaitToStop()
    {
        yield return new WaitForSeconds(1f);
        talking = false;
    }
}