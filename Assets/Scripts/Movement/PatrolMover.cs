using UnityEngine;

public class PatrolMover : MonoBehaviour
{
    [SerializeField] Transform[] _pathPoints;
    [SerializeField] float _offsetError = 0.01f;

    private Transform _currentPathPoint;
    private int _currentPathPointIndex;

    private void Awake()
    {
        _currentPathPointIndex = 0;
        _currentPathPoint = _pathPoints[_currentPathPointIndex];
    }

    public void Move(float speed)
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPathPoint.position, speed * Time.fixedDeltaTime);

        if (Mathf.Abs(transform.position.x - _currentPathPoint.position.x) <= _offsetError)
            SetNextPathPoint();
    }

    private void SetNextPathPoint()
    {
        _currentPathPointIndex = ++_currentPathPointIndex % _pathPoints.Length;
        _currentPathPoint = _pathPoints[_currentPathPointIndex];
    }
}
