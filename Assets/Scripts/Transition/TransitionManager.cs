using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Transite to another scene.
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        // Start running the game if the game was paused.
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
