using UnityEngine;

public class PatrolMover : MonoBehaviour
{
    [SerializeField] Transform[] _pathPoints;
    [SerializeField] float _speed;
    [SerializeField] float _offsetError = 0.01f;

    private Transform _currentPathPoint;
    private int _currentPathPointIndex;

    private void Awake()
    {
        _currentPathPointIndex = 0;
        _currentPathPoint = _pathPoints[_currentPathPointIndex];
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPathPoint.position, _speed * Time.fixedDeltaTime);
    }

    private void FixedUpdate()
    {
        Move();

        if (Mathf.Abs(transform.position.x - _currentPathPoint.position.x) <= _offsetError)
        {
            SetNextPathPoint();
        }
    }

    private void SetNextPathPoint()
    {
        _currentPathPointIndex = ++_currentPathPointIndex % _pathPoints.Length;
        _currentPathPoint = _pathPoints[_currentPathPointIndex];
    }
}
