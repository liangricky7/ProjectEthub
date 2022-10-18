using UnityEngine;
using UnityEngine.UI;
public class BossHealthBar : MonoBehaviour
{
    private Slider slider;
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void SetMaxHealth(float health) {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(float health) {
        slider.value = health;
    }
}
