using System.Collections;
using UnityEngine;

public class HealthSmoothSliderView : HealthSliderView
{
    [SerializeField] private float _changeValueTime = 1f;

    private int lastHealthValue = -1;

    protected override void UpdateView(int health, int maxHealth)
    {
        HealthSlider.maxValue = maxHealth;

        if (lastHealthValue == -1)
            lastHealthValue = maxHealth;

        StartCoroutine(ChangeSmoothlyHealthSliderValue(health));
    }

    private IEnumerator ChangeSmoothlyHealthSliderValue(int newHealth)
    {
        int deltaHealth = lastHealthValue - newHealth;

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

    //Нерабочий метод
    //private IEnumerator ChangeSmoothlyHealthSliderValue(int newHealth)
    //{
    //    float changeSpeed = (HealthSlider.value - newHealth)  / _changeValueTime;

    //    var changeDelay = new WaitForFixedUpdate();

    //    while (HealthSlider.value != newHealth)
    //    {
    //        HealthSlider.value = Mathf.MoveTowards(HealthSlider.value, newHealth, changeSpeed * Time.fixedDeltaTime);
    //        yield return changeDelay;
    //    }
    //}
}
