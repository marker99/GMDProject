using UnityEngine;

public class StaticEnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    [SerializeField] private bool moveInDifferentDirection = false;

    
    private bool moveRight;
    private float distanceMoved;
    private Rigidbody rb;

    void Start()
    {
        moveRight = true;
        distanceMoved = 0f;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveDistance = moveSpeed * Time.deltaTime;

        //Moving up and down
        if (moveInDifferentDirection is false)
        {
            if (moveRight)
            {
                rb.MovePosition(rb.position + (new Vector3(0f, 0f, moveDistance)));
                distanceMoved += moveDistance;
            }
            else
            {
                rb.MovePosition(rb.position - (new Vector3(0f, 0f, moveDistance)));
                distanceMoved -= moveDistance;
            }
        }
        //Moving from side to side
        else
        {
            if (moveRight)
            {
                rb.MovePosition(rb.position + (new Vector3(moveDistance, 0f, 0f)));
                distanceMoved += moveDistance;
            }
            else
            {
                rb.MovePosition(rb.position - (new Vector3(moveDistance, 0f, 0f)));
                distanceMoved -= moveDistance;
            }
        }

        if (Mathf.Abs(distanceMoved) >= 5f)
        {
            // Flip the move direction
            moveRight = !moveRight;
            distanceMoved = 0f;
        }
    }
}