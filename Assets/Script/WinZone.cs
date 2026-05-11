using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(
                "Final Score = " +
                ScoreManager.instance.score
            );

            // เซฟคะแนน
            PlayerPrefs.SetInt(
                "FinalScore",
                ScoreManager.instance.score
            );

            // เปลี่ยนหน้า
            SceneManager.LoadScene("WinScene");
        }
    }
}