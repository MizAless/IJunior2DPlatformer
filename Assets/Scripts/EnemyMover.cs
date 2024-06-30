using UnityEngine;

[RequireComponent(typeof(ChaseMover))]
[RequireComponent(typeof(PatrolMover))]
[RequireComponent(typeof(PlayerDetector))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _patrolSpeed;
    [SerializeField] private float _chaseSpeed;

    private ChaseMover _chaseMover;
    private PatrolMover _patrolMover;
    private PlayerDetector _playerDetector;

    private Vector3 moveDirection;
    private Vector3 previousPoint;

    private void Awake()
    {
        _chaseMover = GetComponent<ChaseMover>();
        _patrolMover = GetComponent<PatrolMover>();
        _playerDetector = GetComponent<PlayerDetector>();

        previousPoint = transform.position;
    }

    private void FixedUpdate()
    {
        moveDirection = transform.position - previousPoint; 
        previousPoint = transform.position;

        if (_playerDetector.IsSeePlayer(moveDirection, out Player player))
            _chaseMover.Move(_chaseSpeed, player.transform);
        else
            _patrolMover.Move(_patrolSpeed);
    }
}
