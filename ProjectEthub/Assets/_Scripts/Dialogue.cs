using UnityEngine;

[System.Serializable]
public class Dialogue : MonoBehaviour {
    new public string name;

    [TextArea(3, 10)]
    public string[] sentences;
}
