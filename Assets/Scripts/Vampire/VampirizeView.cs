using UnityEngine;
using UnityEngine.UI;

public class VampirizeView : MonoBehaviour
{
    private const int RadiusToDiameter = 2;

    [SerializeField] private Vampire _vampire;
    [SerializeField] private Transform _vampirizeArea;
    [SerializeField] private VampirizeModel _vampirizeModel;
    [SerializeField] private Slider _vampirizeCooldownSlider;

    private void Awake()
    {
        float areaDiameter = _vampire.VampirizeRadius * RadiusToDiameter;
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
        _vampirizeModel.gameObject.SetActive(true);
    }

    private void ActivateSlider()
    {
        _vampirizeCooldownSlider.gameObject.SetActive(true);
    }

    private void DisactivateView()
    {
        _vampirizeModel.gameObject.SetActive(false);
    }

    private void DisactivateSlider()
    {
        _vampirizeCooldownSlider.gameObject.SetActive(false);
    }

    private void ChangeCooldownSliderValue(float value)
    {
        float normalizedValue = value / _vampire.VampirizeCooldown;
        _vampirizeCooldownSlider.value = normalizedValue;
    }
}
