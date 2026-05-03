using UnityEngine;

public class Wind : MonoBehaviour
{
    public float force = 20f;
    public AudioClip windSound;           // ใส่เสียงลมตรงนี้
    [Range(0f, 1f)] public float soundVolume = 0.7f; // ปรับความดัง

    private AudioSource audioSource;

    void Start()
    {
        // สร้าง AudioSource สำหรับเล่นเสียงลม
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // เล่นเสียงลมเต็มเสียงทันที
            if (windSound != null)
            {
                audioSource.PlayOneShot(windSound, soundVolume);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ดัน Player ขึ้น
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * force);
            }
        }
    }
}