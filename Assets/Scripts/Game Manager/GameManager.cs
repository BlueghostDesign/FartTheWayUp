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
            // Updates the floor level shown on the screen.
            floorScore.text = elevator.GetFloor().ToString();
        }
        CheckHighScore();
        SetHighScoreText();
    }

    public void RestartGame()
    {
        // Reload the In-Game scene.
        SceneManager.LoadScene(1);
        // Start running the game.
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        // Show the pause UI.
        instance.pauseUI.SetActive(true);
        instance.bgm.StopBGM();
        // Pause the game.
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        // Close the pause UI.
        instance.pauseUI.SetActive(false);
        instance.bgm.StartBGM();
        // Start running the game.
        Time.timeScale = 1;
    }

    public static void GameOver()
    {
        instance.bgm.StopBGM();
        // Show gameover UI.
        instance.gameoverUI.SetActive(true);
        // Plays gameover SFX.
        instance.gameoverSound.Play();
        // Pause the game.
        Time.timeScale = 0f;
    }

    private void CheckHighScore()
    {
        // Updates the highscore.
        if (elevator.GetFloor() > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", elevator.GetFloor());
        }
    }

    private void SetHighScoreText()
    {
        // Show highscore on screen.
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
