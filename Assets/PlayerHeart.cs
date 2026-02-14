using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hearts = 3;

    public void ReduceHeart(int amount)
    {
        hearts -= amount;
        Debug.Log("Hearts Left: " + hearts);

        if (hearts <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        // Restart scene or stop game
        Time.timeScale = 0;
    }
 }
