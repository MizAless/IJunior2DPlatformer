using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Jumper), typeof(Mover), typeof(Health))]
[RequireComponent(typeof(Wallet), typeof(GroundDetector), typeof(InputReader))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(HealDetector))]
[RequireComponent(typeof(Vampire))]
public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Jumper _jumper;
    private Mover _mover;
    private PlayerAnimator _playerAnimator;
    private Health _health;
    private Wallet _wallet;
    private Vampire _vimpire;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _jumper = GetComponent<Jumper>();
        _mover = GetComponent<Mover>();
        _playerAnimator = GetComponent<PlayerAnimator>();
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
        _vimpire = GetComponent<Vampire>();
    }

    private void OnEnable()
    {
        _inputReader.Vapirized += _vimpire.Vampirize;
    }

    private void OnDisable()
    {
        _inputReader.Vapirized -= _vimpire.Vampirize;
    }

    private void FixedUpdate()
    {
        if (_inputReader.HorizontalMove != 0)
            _mover.Move(_inputReader.HorizontalMove);

        if (_inputReader.IsJump && _groundDetector.IsGround)
            _jumper.Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
            _wallet.AddCoins(coin.Collect());
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}
