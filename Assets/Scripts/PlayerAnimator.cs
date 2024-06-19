using UnityEngine;

[RequireComponent(typeof(Animator), typeof(InputReader), typeof(Jumper))]
public class PlayerAnimator : MonoBehaviour
{
    private const string IsWalking = nameof(IsWalking);
    private const string IsJumping = nameof(IsJumping);

    private bool _isWalking = false;
    private bool _isJumping = false;

    private Animator _animator;
    private InputReader _inputReader;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _inputReader = GetComponent<InputReader>();
    }

    private void FixedUpdate()
    {
        _isJumping = _inputReader.IsJump;
        _isWalking = _inputReader.HorizontalMove != 0;

        _animator.SetBool(IsWalking, _isWalking);
        _animator.SetBool(IsJumping, _isJumping);
    }
}
