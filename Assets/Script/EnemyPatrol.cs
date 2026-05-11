using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] points;
    public float speed = 3f;

    private int currentPoint = 0;

    void Update()
    {
        if (points.Length == 0) return;

        Transform target = points[currentPoint];

        // เดินไปยังจุด
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // หันหน้าไปทางที่เดิน
        transform.LookAt(target);

        // ถ้าถึงจุด
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            currentPoint++;

            // วนกลับจุดแรก
            if (currentPoint >= points.Length)
                currentPoint = 0;
        }
    }

    // ชนผู้เล่นแล้วตาย
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player Dead");

            // รีสตาร์ทเกม
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}