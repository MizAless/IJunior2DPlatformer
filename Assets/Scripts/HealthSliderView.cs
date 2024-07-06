using UnityEngine;
using UnityEngine.UI;

public class HealthSliderView : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] Slider _healthSlider;

    private void OnEnable()
    {
        _health.Changed += SetHealthSliderValue;
    }

    private void OnDisable()
    {
        _health.Changed -= SetHealthSliderValue;
    }

    private void SetHealthSliderValue(int health, int maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = health;
    }
}
