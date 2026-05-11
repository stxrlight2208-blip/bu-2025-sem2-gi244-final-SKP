using UnityEngine;
using TMPro;

public class WinUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        int finalScore =
            PlayerPrefs.GetInt("FinalScore");

        Debug.Log(finalScore);

        scoreText.text =
            "Your Score : " + finalScore;
    }
}