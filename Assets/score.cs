using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TMP_Text scoreText;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void AddScore(int val)
    {
        score += val;
        scoreText.text = "Score: " + score;
    }
}
