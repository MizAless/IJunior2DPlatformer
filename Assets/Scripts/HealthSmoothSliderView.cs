using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSliderView : MonoBehaviour
{
    [SerializeField] Health _health;
    [SerializeField] Slider _healthSlider;
    [SerializeField] float changeValueTime = 1f;

    private int lastHealthValue = -1;

    private int CurrentHealth => (int)Mathf.Round(_healthSlider.value);

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

        if (lastHealthValue == -1)
            lastHealthValue = maxHealth;

        StartCoroutine(ChangeSmoothlyHealthSliderValue(health));
    }

    private IEnumerator ChangeSmoothlyHealthSliderValue(int newHealth)
    {
        int deltaHealth = lastHealthValue - newHealth;

        lastHealthValue = newHealth;

        float changedHealthValue = 0;
        float changeSpeed = deltaHealth / changeValueTime;
        float fixedFrameDeltaHealth = changeSpeed * Time.fixedDeltaTime;

        var changeDelay = new WaitForFixedUpdate();

        while (Mathf.Abs(changedHealthValue) < Mathf.Abs(deltaHealth))
        {
            _healthSlider.value -= fixedFrameDeltaHealth;
            changedHealthValue += fixedFrameDeltaHealth;
            yield return changeDelay;
        }

        _healthSlider.value -= deltaHealth - changedHealthValue;
    }
}
