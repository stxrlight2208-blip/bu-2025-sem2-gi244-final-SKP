using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCredits : MonoBehaviour
{
    public void GoEnd()
    {
        SceneManager.LoadScene("End Credits");
    }
}