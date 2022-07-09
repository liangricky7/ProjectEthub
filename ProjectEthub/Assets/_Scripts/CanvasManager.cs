using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    #region Singleton
    public static CanvasManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion

    public GameObject InventoryCanvas;
}
