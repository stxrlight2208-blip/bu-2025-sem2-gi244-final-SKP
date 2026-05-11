using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    public float moveSpeed = 10f;

    private Transform player;

    void Start()
    {
        player =
            GameObject.FindGameObjectWithTag("Player")
            .transform;
    }

    void Update()
    {
        float distance =
            Vector3.Distance(
                transform.position,
                player.position
            );

        // ถ้าเข้าใกล้ค่อยดูด
        if (distance < 5f)
        {
            transform.position =
                Vector3.MoveTowards(
                    transform.position,
                    player.position,
                    moveSpeed * Time.deltaTime
                );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(coinValue);

            Destroy(gameObject);
        }
    }
}