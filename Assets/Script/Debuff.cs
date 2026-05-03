using UnityEngine;

public class ConfuseDebuff : MonoBehaviour
{
    public float duration = 5f;
    public AudioClip collisionSound;      // ใส่เสียงชนตรงนี้
    [Range(0f, 1f)] public float soundVolume = 0.8f; // ปรับความดัง 0-1

    private AudioSource audioSource;

    void Start()
    {
        // สร้าง AudioSource สำหรับเล่นเสียงชน
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // เล่นเสียงชนซ้อน Background
            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound, soundVolume);
            }

            PlayerController pm = other.GetComponent<PlayerController>();
            if (pm != null)
            {
                StartCoroutine(ApplyDebuff(pm));
            }
        }
    }

    System.Collections.IEnumerator ApplyDebuff(PlayerController player)
    {
        player.isConfused = true;
        yield return new WaitForSeconds(duration);
        player.isConfused = false;
    }
}