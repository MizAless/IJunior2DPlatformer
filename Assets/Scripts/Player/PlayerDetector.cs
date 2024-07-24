using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _seeDistance;
    [SerializeField] private LayerMask _playerLayerMask;

    public bool IsSeePlayer(Vector3 seeDirection, out Player player)
    {
        bool isSeePlayer = false;
        player = null;

        seeDirection = seeDirection.normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, seeDirection, _seeDistance, _playerLayerMask);

        Debug.DrawRay(transform.position, seeDirection * _seeDistance, Color.yellow);

        if (hit.collider != null && hit.collider.TryGetComponent(out Player foundPlayer))
        {
            isSeePlayer = true;
            player = foundPlayer;
        }

        return isSeePlayer;
    }
}
