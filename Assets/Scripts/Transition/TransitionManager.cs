using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public void Awake()
    {
        Application.targetFrameRate = 60;
    }
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
