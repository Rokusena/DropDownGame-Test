using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{
   
    public void LoadNextScene()
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

       
        SceneManager.LoadScene(currentSceneIndex + 1);

      
    }
}
