using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 7f;

    private Rigidbody rb;
    private bool isGrounded;

    public bool isConfused = false; // debuff

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ถ้าติด debuff → สลับทิศ
        if (isConfused)
        {
            h = -h;
            v = -v;
        }

        Vector3 move = new Vector3(h, 0, v);
        rb.AddForce(move * moveForce);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // ฟังก์ชันโดน debuff
    public void ApplyConfuse(float duration)
    {
        StartCoroutine(ConfuseRoutine(duration));
    }

    IEnumerator ConfuseRoutine(float duration)
    {
        isConfused = true;
        yield return new WaitForSeconds(duration);
        isConfused = false;
    }
}