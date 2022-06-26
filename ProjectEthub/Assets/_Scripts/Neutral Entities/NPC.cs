using UnityEngine;
using UnityEngine.UI;

public class NPC : Interactable {

    private bool canBeInteractedWith = false;
    private DialogueManager DManager;
    // Start is called before the first frame update
    void Awake() {
        DManager = FindObjectOfType<DialogueManager>();
    }

    private void Update() {
        if (Input.GetKeyDown("e") && canBeInteractedWith) {
            Interact();
        }
    }
    public override void Interact() { //speaking and shit
        if (DManager.inDialogue == false) {
            DManager.StartDialogue(gameObject.GetComponent<Dialogue>());
        } else {
            DManager.DisplayNextSentence();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log(collider.tag);
        if (collider.tag == "Player") {
            Debug.Log("talk to me");
            canBeInteractedWith = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            Debug.Log("dont talk to me");
            canBeInteractedWith = false;
        }
    }
}
