using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Gamemaniger gameManager;

    private void Start()
    {
        
        gameManager = FindObjectOfType<Gamemaniger>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager script not found in the scene.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Fruit fruit = other.GetComponent<Fruit>();

        if (fruit != null)
        {
            
            if (gameManager != null && gameManager.CurrentScore > gameManager.HighScore)
            {
                gameManager.HighScore = gameManager.CurrentScore;
                
                PlayerPrefs.SetInt("HighScore", gameManager.HighScore);
                PlayerPrefs.Save();
            }

           
            gameManager.RestartGame();
        }
    }
}
