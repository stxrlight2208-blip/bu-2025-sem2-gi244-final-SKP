using UnityEngine;

public class SmartEnemy : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float detectRange = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            Patrol();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        // check ground ก่อนเดิน
        if (!IsGroundAhead())
        {
            Flip();
            return;
        }

        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);

        if (direction.x > 0 && !movingRight) Flip();
        if (direction.x < 0 && movingRight) Flip();
    }

    void Patrol()
    {
        if (!IsGroundAhead())
        {
            Flip();
        }

        float move = movingRight ? 1 : -1;
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
    }

    bool IsGroundAhead()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundDistance, groundLayer);
        return hit.collider != null;
    }

    void Flip()
    {
        movingRight = !movingRight;
        transform.localScale = new Vector3(movingRight ? 1 : -1, 1, 1);
    }
}