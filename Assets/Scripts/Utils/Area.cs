using UnityEngine;

public class Area : MonoBehaviour
{
    private float _xPosition;
    private float _xScale;
    private float _yPosition;

    public float YPosition => _yPosition;

    private void Awake()
    {
        _xPosition = transform.position.x;
        _xScale = transform.localScale.x;
        _yPosition = transform.position.y;
    }

    public float GetRandomXCoordinate()
    {
        float xOffset = _xScale / 2f;
        return Random.Range(_xPosition - xOffset, _xPosition + xOffset);
    }
}
