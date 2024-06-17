using System.Collections;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private float _jumpTime = 0.1f;

    private bool _isJump = false;

    public float HorizontalMove { get; private set; }

    public bool IsJump => _isJump;

    private void Update()
    {
        HorizontalMove = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(_jumpKey))
            StartCoroutine(JumpInputCoroutine());
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }

    private IEnumerator JumpInputCoroutine()
    {
        _isJump = true;
        yield return new WaitForSeconds(_jumpTime);
        _isJump = false;
    }
}
