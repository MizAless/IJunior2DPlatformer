using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(Jumper), typeof(Mover), typeof(Health))]
[RequireComponent(typeof(Wallet), typeof(GroundDetector), typeof(InputReader))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(HealDetector))]
public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private Jumper _jumpController;
    private Mover _moveController;
    private PlayerAnimator _playerAnimationController;
    private Health _health;
    private Wallet _wallet;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _jumpController = GetComponent<Jumper>();
        _moveController = GetComponent<Mover>();
        _playerAnimationController = GetComponent<PlayerAnimator>();
        _health = GetComponent<Health>();
        _wallet = GetComponent<Wallet>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.HorizontalMove != 0)
            _moveController.Move(_inputReader.HorizontalMove);

        if (_inputReader.IsJump && _groundDetector.IsGround)
            _jumpController.Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
            _wallet.AddCoins(coin.Collect());
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
