using TMPro;
using UnityEngine;

public class HealthTextView : HealthView
{
    [SerializeField] private string _healthTextValue = "Health: ";
    [SerializeField] private char _separatorSign = '/';
    [SerializeField] private TextMeshProUGUI _healthText;

    protected override void UpdateView(int health, int maxHealth)
    {
        _healthText.text = _healthTextValue + health + _separatorSign + maxHealth;
    }
}
