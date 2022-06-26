using UnityEngine;
//for all interactable objects
public class Interactable : MonoBehaviour {
    public virtual void Interact() {
        Debug.Log("interacting with " + transform.name);
    }
}
