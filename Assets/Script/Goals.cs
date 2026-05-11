using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("WIN!");

            // เซฟคะแนน
            PlayerPrefs.SetInt(
                "FinalScore",
                ScoreManager.instance.score
            );

            // ไปหน้า Win
            SceneManager.LoadScene("Win");
        }
    }
}