using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float speed;

    [SerializeField] CameraBounds2D bounds;
    Vector2 maxXPositions, maxYPositions;

    void Awake()
    {
        InitializeBounds(bounds);
    }

    public void InitializeBounds(CameraBounds2D bound)
    {
        bound.Initialize(GetComponent<Camera>());
        maxXPositions = bound.maxXlimit;
        maxYPositions = bound.maxYlimit;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(Mathf.Clamp(player.position.x, maxXPositions.x, maxXPositions.y), Mathf.Clamp(player.position.y, maxYPositions.x, maxYPositions.y), -10);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * speed);
    }

}