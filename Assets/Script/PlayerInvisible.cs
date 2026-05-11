using UnityEngine;

public class PlayerInvisible : MonoBehaviour
{
    public bool isInvisible = false;

    public float invisibleDuration = 5f;
    public float cooldown = 30f;

    private bool canUseSkill = true;

    void Update()
    {
        // กด E ใช้สกิล
        if (Input.GetKeyDown(KeyCode.E) && canUseSkill)
        {
            StartCoroutine(InvisibleSkill());
        }
    }

    System.Collections.IEnumerator InvisibleSkill()
    {
        canUseSkill = false;

        isInvisible = true;

        Debug.Log("Invisible ON");

        yield return new WaitForSeconds(invisibleDuration);

        isInvisible = false;

        Debug.Log("Invisible OFF");

        yield return new WaitForSeconds(cooldown);

        canUseSkill = true;

        Debug.Log("Skill Ready");
    }
}