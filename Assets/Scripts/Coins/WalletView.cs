using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    private const string Coins = "Coins: ";

    [SerializeField] private Wallet _wallet;
    [SerializeField] private TextMeshProUGUI _coinsText;

    private void OnEnable()
    {
        _wallet.Changed += SetCoinsText;
    }

    private void OnDisable()
    {
        _wallet.Changed -= SetCoinsText;
    }

    private void SetCoinsText(int count)
    {
        _coinsText.text = Coins + count;
    }
}
