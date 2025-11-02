using UnityEngine;

public class BeetleMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed = 2f;

    private Vector3 targetDirection = Vector3.left; // Start moving left

    void Start()
    {
        FaceDirection(targetDirection);
    }

    void Update()
    {
        // Move the beetle
        transform.Translate(targetDirection * moveSpeed * Time.deltaTime);

        // Check if beetle passed the start or end point based on direction
        if (targetDirection == Vector3.left && transform.position.x <= startPoint.position.x)
        {
            FlipDirection(Vector3.right); // Move toward endPoint
        }
        else if (targetDirection == Vector3.right && transform.position.x >= endPoint.position.x)
        {
            FlipDirection(Vector3.left); // Move toward startPoint
        }
    }

    void FlipDirection(Vector3 newDirection)
    {
        targetDirection = newDirection;
        FaceDirection(newDirection);
    }

    void FaceDirection(Vector3 direction)
    {
        Vector3 localScale = transform.localScale;
        localScale.x = Mathf.Sign(direction.x) * Mathf.Abs(localScale.x);
        transform.localScale = localScale;
    }
}
