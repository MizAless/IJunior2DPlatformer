using UnityEngine;
using UnityEngine.UI;

public class HealthSliderView : HealthView
{
    [SerializeField] protected Slider HealthSlider;

    protected override void UpdateView(int health, int maxHealth)
    {
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = health;
    }
}
