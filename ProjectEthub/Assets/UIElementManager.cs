using UnityEngine;

public class UIElementManager : MonoBehaviour
{
    #region Singleton
    public static UIElementManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion
    public GameObject HealthBar;
}
