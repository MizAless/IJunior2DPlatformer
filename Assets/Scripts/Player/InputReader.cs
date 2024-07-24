using System;
using System.Collections;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _vampirizeKey = KeyCode.Mouse0;
    [SerializeField] private float _jumpDisableDelay = 0.1f;

    private bool _isJump = false;
    private bool _needVapirize = false;

    public float HorizontalMove { get; private set; }

    public bool IsJump => _isJump;

    public event Action Vapirized;

    private void Update()
    {
        HorizontalMove = Input.GetAxisRaw(Horizontal);

        if (Input.GetKeyDown(_jumpKey))
            StartCoroutine(JumpInputCoroutine());

        if (Input.GetKeyDown(_vampirizeKey))
            Vapirized?.Invoke();
    }

    private IEnumerator JumpInputCoroutine()
    {
        _isJump = true;
        yield return new WaitForSeconds(_jumpDisableDelay);
        _isJump = false;
    }
}
