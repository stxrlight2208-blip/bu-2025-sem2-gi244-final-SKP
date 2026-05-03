using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public GameObject winUI; // ลาก Panel หรือ Text ของ UI Win มาที่นี่

    private void Start()
    {
        if (winUI != null)
            winUI.SetActive(false); // ซ่อน UI ตอนเริ่มเกม
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Win!");

            if (winUI != null)
            {
                winUI.SetActive(true); // แสดง UI Win
            }
        }
    }
}