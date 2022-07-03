using UnityEngine;

public class InventorySlotManager : MonoBehaviour
{
    #region Singleton
    public static InventorySlotManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion

    public GameObject WeaponSlot;
}
