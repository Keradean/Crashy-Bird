using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int birdScore;
    [SerializeField] private Text Score;
    [SerializeField] private GameObject gameOverScreen;
    

    public void addScore(int scoreToAdd)
    {
        birdScore = birdScore + scoreToAdd;
        Score.text = birdScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; 
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0; 
    }
}

