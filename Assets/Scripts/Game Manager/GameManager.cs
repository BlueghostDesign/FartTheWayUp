using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Text floorScore;

    public Text highScore;

    public Text goldCollected;

    private Elevator elevator;

    public GameObject gameoverUI;

    public GameObject pauseUI;

    public GameObject bagUI;

    private AudioSource gameoverSound;

    private BGM bgm;

    public bool bagOpened;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        elevator = GameObject.Find("Elevator").transform.GetComponent<Elevator>();
        gameoverSound = GetComponent<AudioSource>();
        bgm = GameObject.Find("BGM").transform.GetComponent<BGM>();
        bagOpened = false;
    }

    private void Update()
    {
        if (elevator != null)
        {
            // Updates the floor level shown on the screen.
            floorScore.text = elevator.GetFloor().ToString();
        }
        UpdateHighScore();
        SetHighScoreText();
        UpdateGoldText();
    }

    public void RestartGame()
    {
        // Start running the game.
        Time.timeScale = 1;
        // Reload the In-Game scene.
        SceneManager.LoadScene(1);
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

    public void Bag()
    {
        if (bagOpened)
        {
            // Close the bag UI if opened already.
            instance.bagUI.SetActive(false);
            bagOpened = false;
        }
        else
        {
            // Open the bag UI.
            instance.bagUI.SetActive(true);
            bagOpened = true;
        }
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

    private void UpdateHighScore()
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

    private void UpdateGoldText()
    {
        goldCollected.text = $"Gold Collected: {elevator.GetGoldCollected()}";
    }
}
