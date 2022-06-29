using UnityEngine;
public class ItemPickup : Interactable {
    private bool canBeInteractedWith = false;
    public Item item;
    private SpriteRenderer render;
    private void Start() {
        render = gameObject.GetComponent<SpriteRenderer>();
        render.sprite = item.icon;
    }
    public void Initialize(Item newItem) {
        item = newItem;
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
    private void OnCollisionEnter2D(Collision2D collider) {
        Interact();
    }
}
