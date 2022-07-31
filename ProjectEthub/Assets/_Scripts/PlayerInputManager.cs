using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public void EInputHandler() {
        if (UIManager.instance.inMenuUI) {
            SlotSelector.instance.Equip();
        } else {
            Debug.Log("insert talking to NPC");
        }
    }
}
