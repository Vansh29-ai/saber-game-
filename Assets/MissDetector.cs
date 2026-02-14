using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MissDetector : MonoBehaviour
{
    public TextMeshProUGUI missText;
     public int missCount = 0;
     public int miss= 5;
    public int maxMiss = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Beat"))
        {
            missCount++;
            miss--;

            Destroy(other.gameObject);
            UpdateUI();

            if (missCount >= maxMiss)
                GameOver();
        }
    }

    void UpdateUI()
    {
        missText.text = miss.ToString();
    }

    void GameOver()
    {
        SceneManager.LoadSceneAsync(3);
        Time.timeScale = 0f;
    }
}
