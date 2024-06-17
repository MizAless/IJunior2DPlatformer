using System;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _coinsCount = 0;

    public event Action<int> Changed;

    public void AddCoins(int count)
    {
        _coinsCount += count;
        Changed?.Invoke(_coinsCount);
    }
}
