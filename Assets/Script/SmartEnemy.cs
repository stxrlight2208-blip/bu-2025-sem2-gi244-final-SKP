using UnityEngine;
using UnityEngine.SceneManagement;

public class SmartEnemy : MonoBehaviour
{
    public Transform player;

    public float speed = 3f;

    // ระยะที่เริ่มไล่
    public float chaseDistance = 5f;

    void Update()
    {
        if (player == null) return;

        // วัดระยะ
        float distance =
            Vector3.Distance(transform.position, player.position);

        // ถ้าอยู่ใกล้ค่อยไล่
        if (distance <= chaseDistance)
        {
            Vector3 targetPosition = new Vector3(
                player.position.x,
                transform.position.y,
                player.position.z
            );

            // เดินตาม
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );

            // หันหน้า
            transform.LookAt(targetPosition);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");

            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}