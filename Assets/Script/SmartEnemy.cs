using UnityEngine;
using UnityEngine.SceneManagement;

public class SmartEnemy : MonoBehaviour
{
    public Transform player;

    private PlayerInvisible playerSkill;

    public float speed = 3f;

    // ระยะที่เริ่มไล่
    public float chaseDistance = 5f;

    void Start()
    {
        // หา Script ล่องหนจาก Player
        playerSkill = player.GetComponent<PlayerInvisible>();
    }

    void Update()
    {
        if (player == null) return;

        // ถ้าผู้เล่นล่องหน Enemy จะไม่ไล่
        if (playerSkill != null && playerSkill.isInvisible)
        {
            return;
        }

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