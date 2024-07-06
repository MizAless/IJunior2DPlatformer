using TMPro;
using UnityEngine;

public class HealthTextView : MonoBehaviour
{
    [SerializeField] private string _healthTextValue = "Health: ";
    [SerializeField] private char _separatorSign = '/';
    [SerializeField] private Health _health;
    [SerializeField] private TextMeshProUGUI _healthText;

    private void OnEnable()
    {
        _health.Changed += SetHealthText;
    }

    private void OnDisable()
    {
        _health.Changed -= SetHealthText;
    }

    private void SetHealthText(int health, int maxHealth)
    {
        _healthText.text = _healthTextValue + health + _separatorSign + maxHealth;
    }
}
