using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnEnable() => _health.Changed += UpdateView;

    private void OnDisable() => _health.Changed -= UpdateView;

    protected abstract void UpdateView(float health, float maxHealth);
}
