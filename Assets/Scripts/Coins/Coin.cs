using UnityEngine;

public class Coin : MonoBehaviour 
{
    [SerializeField] private int _cost = 1;

    public int Collect()
    {
        Destroy(gameObject);
        return _cost;
    }
}
