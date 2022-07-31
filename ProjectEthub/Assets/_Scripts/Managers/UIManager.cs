using UnityEngine;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject inGameUI;
    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject InventoryPanel;
    //[SerializeField]
    //private GameObject MapPanel;
    //[SerializeField]
    //private GameObject QuestPanel;
    [SerializeField]
    private GameObject SettingsPanel;

    public bool inMenuUI;
    private CanvasGroup menuCanvasGroup;

    public bool inInventory;
    //private bool inMap;
    //private bool inQuest;
    public bool inSettings;

    public static UIManager instance; //made a singleton in order to easily check if game has menu open
    private void Awake() {
        instance = this;
        menuCanvasGroup = menuUI.GetComponent<CanvasGroup>();
        InventoryPanel.SetActive(false);
        //MapPanel.SetActive(false);
        //QuestPanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
    private void Start() {
        InitializeMenu();
    }

    #region for keyboard inputs
    public void InputInventory() {
        if (inInventory) {
            ExitMenu();
            inInventory = false;
        } else {
            InventoryUI();
        }
    }
    //public void InputMap() {
    //    if (inMap) {
    //        ExitMenu();
    //        inMap = false;
    //    } else {
    //        Map();
    //    }
    //}
    //public void InputQuest() {
    //    if (inQuest) {
    //        ExitMenu();
    //        inQuest = false;

    //    } else {
    //        Quest();
    //    }
    //}
    #endregion
    private void EnterMenu() {
        inMenuUI = true;
        menuCanvasGroup.alpha = 1;
        menuCanvasGroup.interactable = true;
        menuCanvasGroup.blocksRaycasts = true;
        inGameUI.SetActive(false);
        Time.timeScale = 0;
    }


    public void InventoryUI() {
        if (inInventory) { //repeated button presses do nothing
            return;
        }
        if (!inMenuUI) { //if not already in menu, pull up the menu bar
            EnterMenu();
        }
        ClosePreviousPanel();
        inInventory = true;
        InventoryPanel.SetActive(true); //actually displays the inventory
        Inventory.instance.UIOpen(); //refreshes the inventory in the event an item was added
    }


    //public void Map() {
    //    if (inMap) { //repeated button presses do nothing
    //        return;
    //    }
    //    if (!inMenuUI) { //if not already in menu, pull up the menu bar
    //        EnterMenu();
    //    }
    //    ClosePreviousPanel();
    //    inMap = true;
    //    MapPanel.SetActive(true);
    //}

    //public void Quest() {
    //    if (inQuest) { //repeated button presses do nothing
    //        return;
    //    }
    //    if (!inMenuUI) { //if not already in menu, pull up the menu bar
    //        EnterMenu();
    //    }
    //    ClosePreviousPanel();
    //    inQuest = true;
    //    QuestPanel.SetActive(true);
    //}

    public void Settings() {
        if (inSettings) { //repeated button presses do nothing
            return;
        }
        if (!inMenuUI) { //if not already in menu, pull up the menu bar
            EnterMenu();
        }
        Debug.Log("entered Settings");
    }

    private void ClosePreviousPanel() {
        if (inInventory) {
            inInventory = false;
            InventoryPanel.SetActive(false);
            SlotSelector.instance.SelectSlot(null, SlotSelector.instance.currentID); //deselects the last selected slot
        //} else if (inMap) {
        //    inMap = false;
        //    MapPanel.SetActive(false);

        //} else if (inQuest) {
        //    inQuest = false;
        //    QuestPanel.SetActive(false);

        } else if (inSettings) {
            inSettings = false;
            SettingsPanel.SetActive(false);
        }
    }
    public void ExitMenu() {
        inMenuUI = false;
        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;
        inGameUI.SetActive(true);
        ClosePreviousPanel();
        Time.timeScale = 1;
    }

    private void InitializeMenu() {
        inMenuUI = false;
        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;
        inGameUI.SetActive(true);
        Time.timeScale = 1;
    }
    
}
