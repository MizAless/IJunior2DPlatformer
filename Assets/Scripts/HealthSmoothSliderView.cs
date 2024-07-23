using System.Collections;
using UnityEngine;

public class HealthSmoothSliderView : HealthSliderView
{
    [SerializeField] private float _changeValueTime = 1f;

    private float lastHealthValue;

    private bool _isFirstChange = true;

    protected override void UpdateView(float health, float maxHealth)
    {
        HealthSlider.maxValue = maxHealth;

        if (_isFirstChange)
        {
            lastHealthValue = maxHealth;
            _isFirstChange = false;
        }

        StartCoroutine(ChangeSmoothlyHealthSliderValue(health));
    }

    private IEnumerator ChangeSmoothlyHealthSliderValue(float newHealth)
    {
        float deltaHealth = lastHealthValue - newHealth;

        lastHealthValue = newHealth;

        float changedHealthValue = 0;
        float changeSpeed = deltaHealth / _changeValueTime;
        float fixedFrameDeltaHealth = changeSpeed * Time.fixedDeltaTime;

        var changeDelay = new WaitForFixedUpdate();

        while (Mathf.Abs(changedHealthValue) < Mathf.Abs(deltaHealth))
        {
            HealthSlider.value -= fixedFrameDeltaHealth;
            changedHealthValue += fixedFrameDeltaHealth;
            yield return changeDelay;
        }

        HealthSlider.value -= deltaHealth - changedHealthValue;
    }
}
