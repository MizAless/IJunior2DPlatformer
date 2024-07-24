using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] private int _healValue;

    public int HealValue => _healValue;
}
