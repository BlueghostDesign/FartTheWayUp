using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Text floorScore;

    public Text highScore;

    private Elevator elevator;

    public GameObject gameoverUI;

    public GameObject pauseUI;

    private AudioSource gameoverSound;

    private BGM bgm;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        elevator = GameObject.Find("Elevator").transform.GetComponent<Elevator>();
        gameoverSound = GetComponent<AudioSource>();
        bgm = GameObject.Find("BGM").transform.GetComponent<BGM>();;
    }

    private void Update()
    {
        if (elevator != null)
        {
            floorScore.text = elevator.floor.ToString();
        }
        CheckHighScore();
        SetHighScoreText();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        instance.pauseUI.SetActive(true);
        instance.bgm.StopBGM();
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        instance.pauseUI.SetActive(false);
        instance.bgm.StartBGM();
        Time.timeScale = 1;
    }

    public static void GameOver()
    {
        instance.bgm.StopBGM();
        instance.gameoverUI.SetActive(true);
        instance.gameoverSound.Play();
        Time.timeScale = 0f;
    }

    private void CheckHighScore()
    {
        if (elevator.floor > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", elevator.floor);
        }
    }

    private void SetHighScoreText()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
