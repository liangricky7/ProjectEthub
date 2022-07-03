using UnityEngine;

public class UIManager : MonoBehaviour {
    private GameObject[] UICanvases;
    private CanvasGroup InventoryCanvas;
    // Start is called before the first frame update
    void Start() {
        UICanvases = GameObject.FindGameObjectsWithTag("UI");
        for (int i = 0; i < UICanvases.Length; i++) {
            if (UICanvases[i].name.Equals("InventoryCanvas"))
                InventoryCanvas = UICanvases[i].GetComponent<CanvasGroup>();
        }
        openInventory();
    }
    public void openInventory() {
        InventoryCanvas.alpha = (InventoryCanvas.alpha == 0 ? 1 : 0); //if alpha is 0 set to 1 else set to 0
        InventoryCanvas.interactable = !InventoryCanvas.interactable;
        InventoryCanvas.blocksRaycasts = !InventoryCanvas.blocksRaycasts;
    }

    private void OpenUI() {
    
    }
}
