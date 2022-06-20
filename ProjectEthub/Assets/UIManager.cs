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

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("i")) {
            openInventory();
        }
    }


    private void openInventory() {
        InventoryCanvas.alpha = (InventoryCanvas.alpha == 0 ? 1 : 0); //if alpha is 0 set to 1 else set to 0
        InventoryCanvas.interactable = !InventoryCanvas.interactable;
    }
}
