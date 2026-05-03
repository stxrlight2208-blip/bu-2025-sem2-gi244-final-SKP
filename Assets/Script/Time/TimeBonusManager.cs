using UnityEngine;

public class TimeBonusManager : MonoBehaviour
{
    public float startBonus = 30f;     // เริ่ม +30 วิ
    public float decreaseAmount = 10f; // ลดทีละ 10 วิ
    public float interval = 60f;       // ทุก 60 วิ

    public float currentBonus;

    private float timer;

    void Start()
    {
        currentBonus = startBonus;
        timer = interval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            currentBonus -= decreaseAmount;
            currentBonus = Mathf.Max(currentBonus, 0f);

            timer = interval;
        }
    }

    public float GetBonus()
    {
        return currentBonus;
    }
}