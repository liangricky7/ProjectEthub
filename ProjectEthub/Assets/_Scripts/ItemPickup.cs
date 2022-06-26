using UnityEngine;
using UnityEngine.UI;
public class ItemPickup : Interactable {
    private bool canBeInteractedWith = false;
    public Item item;
    
    private void Update() {
        if (Input.GetKeyDown("e") && canBeInteractedWith) {
            Interact();
        }
    }
    public override void Interact() {
        Debug.Log("picked up a " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp) {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            canBeInteractedWith = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.tag == "Player") {
            canBeInteractedWith = false;
        }
    }
}
