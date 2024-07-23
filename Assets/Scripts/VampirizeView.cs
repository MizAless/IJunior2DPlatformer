using UnityEngine;
using UnityEngine.UI;

public class VampirizeView : MonoBehaviour
{
    private const int radiusToDiameter = 2;

    [SerializeField] private Vampire _vampire;
    [SerializeField] private Transform _vampirizeArea;
    [SerializeField] private GameObject _vampirizeModel;
    [SerializeField] private Slider _vampirizeCooldownSlider;

    private void Awake()
    {
        float areaDiameter = _vampire.VampirizeRadius * radiusToDiameter;
        _vampirizeArea.localScale = Vector3.one * areaDiameter;
    }

    private void OnEnable()
    {
        _vampire.VampirizeStarted += ActivateView;
        _vampire.VampirizeEnded += DisactivateView;
        _vampire.VampirizeCooldownStarted += ActivateSlider;
        _vampire.VampirizeCooldownEnded += DisactivateSlider;
        _vampire.CurrentCooldownTimeChanged += ChangeCooldownSliderValue;
    }

    private void OnDisable()
    {
        _vampire.VampirizeStarted -= ActivateView;
        _vampire.VampirizeEnded -= DisactivateView;
    }

    private void ActivateView()
    {
        _vampirizeModel.SetActive(true);
    }

    private void ActivateSlider()
    {
        _vampirizeCooldownSlider.maxValue = _vampire.VampirizeCooldown;
        _vampirizeCooldownSlider.gameObject.SetActive(true);
    }

    private void DisactivateView()
    {
        _vampirizeModel.SetActive(false);
    }

    private void DisactivateSlider()
    {
        _vampirizeCooldownSlider.gameObject.SetActive(false);
    }

    private void ChangeCooldownSliderValue(float value)
    {
        _vampirizeCooldownSlider.value = value;
    }
}
