using UnityEngine;
using UnityEngine.UI;

public class HealthSliderView : HealthView
{
    [SerializeField] protected Slider HealthSlider;

    protected override void UpdateView(float health, float maxHealth)
    {
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = health;
    }
}
