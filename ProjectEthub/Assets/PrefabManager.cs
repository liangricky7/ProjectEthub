using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    #region Singleton
    public static PrefabManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion

    public GameObject ItemPickup;
}
