using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Gamemaniger : MonoBehaviour
{
    private int currentScore = 0;
    private int highScore = 0;

    public int CurrentScore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

    public int HighScore
    {
        get { return highScore; }
        set
        {
            highScore = value;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreText();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateScoreBasedOnFruits()
    {
        GameObject[] fruits = GameObject.FindGameObjectsWithTag("Fruit");

        foreach (GameObject fruit in fruits)
        {
            Fruit fruitScript = fruit.GetComponent<Fruit>();
            currentScore += fruitScript.fruitLevel * 2;
        }

        if (currentScore > highScore)
        {
            HighScore = currentScore;
            UpdateHighScoreText();
        }
    }

    private void UpdateHighScoreText()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

    private void Update()
    {
        if (scoreText != null)
        {
            currentScore = 0;
            UpdateScoreBasedOnFruits();
            scoreText.text = "Score: " + currentScore.ToString();
        }
    }
}
