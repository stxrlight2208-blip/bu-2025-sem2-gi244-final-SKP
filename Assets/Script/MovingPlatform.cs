using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Transform target;
    private Vector3 lastPosition;
    private Vector3 platformVelocity;

    void Start()
    {
        target = pointB;
        lastPosition = transform.position;
    }

    void Update()
    {
        // เคลื่อนที่ platform
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // คำนวณ velocity
        platformVelocity = transform.position - lastPosition;
        lastPosition = transform.position;

        // สลับเป้าหมาย
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            target = target == pointA ? pointB : pointA;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // ขยับ player ตาม platform โดยไม่ต้อง parent
            collision.transform.position += platformVelocity;
        }
    }
}