using UnityEngine;

[SelectionBase]
[RequireComponent(typeof(GroundDetector))]
[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(JumpController))]
[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(PlayerAnimationController))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Wallet))]
public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private JumpController _jumpController;
    private MoveController _moveController;
    private PlayerAnimationController _playerAnimationController;
    private Health _health;
    private Wallet _wallet;

    private void Awake()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _jumpController = GetComponent<JumpController>();
        _moveController = GetComponent<MoveController>();
        _playerAnimationController = GetComponent<PlayerAnimationController>();
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
