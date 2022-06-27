using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour {
    private Queue<string> sentences;
    public bool inDialogue;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject DialoguePanel;

    // Start is called before the first frame update
    void Start() {
        inDialogue = false;
        sentences = new Queue<string>();
        DialoguePanel.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue) {
        inDialogue = true;
        DialoguePanel.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear(); //makes sure the dialogue from last convo is cleared

        foreach (string sentence in dialogue.sentences) { //adds new sentences
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(); //this is what actually prints out the text
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); //takes out next sentence and prints it
        dialogueText.text = sentence;
    }

    public void EndDialogue() {
        inDialogue = false;
        DialoguePanel.SetActive(false);
        Debug.Log("end");
    }

}
