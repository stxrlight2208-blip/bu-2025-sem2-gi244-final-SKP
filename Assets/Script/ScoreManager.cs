using UnityEngine;
using TMPro; // สำคัญ: ต้องใส่เพื่อใช้ TextMeshPro

public class ScoreManager : MonoBehaviour
{
    // สร้าง Singleton เพื่อให้โค้ดอื่นเรียกใช้ได้ง่ายๆ
    public static ScoreManager instance;

    public TMP_Text scoreText; // ลาก Text Object มาใส่ในช่องนี้ใน Inspector
    private int score = 0;    // คะแนนปัจจุบัน

    void Awake()
    {
        // กำหนด Instance ของ Singleton
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        // เริ่มต้นเกม ให้แสดงคะแนนเป็น 0
        UpdateScoreUI();
    }

    // ฟังก์ชันสำหรับเพิ่มคะแนน (โค้ดเหรียญจะเรียกใช้ฟังก์ชันนี้)
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    // ฟังก์ชันสำหรับอัปเดตข้อความบนหน้าจอ
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}