using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _model;

    private float _previousDirection = 1; 

    public void Move(float _horizontalMove)
    {
        transform.position += Vector3.right * _speed * _horizontalMove * Time.fixedDeltaTime;
        
        if (_previousDirection != _horizontalMove)
        {
            _previousDirection = _horizontalMove;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 currentLocalScale = _model.localScale;
        currentLocalScale.x *= -1;
        _model.localScale = currentLocalScale;
    }
}
