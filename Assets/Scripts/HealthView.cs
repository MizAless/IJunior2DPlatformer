using UnityEngine;

abstract public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable() => _health.Changed += UpdateView;

    private void OnDisable() => _health.Changed -= UpdateView;

    protected abstract void UpdateView(int health, int maxHealth);
}
