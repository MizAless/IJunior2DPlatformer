using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]
public class JumpController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private GroundDetector _groundDetector;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    public void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _groundDetector.Jump();
    }
}
