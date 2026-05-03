using UnityEngine;

public class TimeItem : MonoBehaviour
{
    public TimeBonusManager bonusManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float bonus = bonusManager.GetBonus();

            GameManager.instance.AddTime(bonus);

            Destroy(gameObject);
        }
    }
}