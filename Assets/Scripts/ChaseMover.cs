using UnityEngine;

public class ChaseMover : MonoBehaviour
{
    private Transform _target;

    public void Move(float speed, Transform target)
    {
        SetTarget(target);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, speed * Time.fixedDeltaTime);
    }

    private void SetTarget(Transform target)
    {
        _target = target;
    }
}
