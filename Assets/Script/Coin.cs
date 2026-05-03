using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // มูลค่าของเหรียญนี้ (เพิ่มคะแนนเท่าไหร่)

    // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อมี Object อื่นเดินชน (และเหรียญเปิด Is Trigger ไว้)
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจสอบว่า Object ที่ชนมี Tag เป็น "Player" หรือไม่
        if (other.CompareTag("Player"))
        {
            // เรียกฟังก์ชันเพิ่มคะแนนใน ScoreManager
            ScoreManager.instance.AddScore(coinValue);

            // ทำลายเหรียญทิ้ง (เหรียญหายไปจากฉาก)
            Destroy(gameObject);
        }
    }
}