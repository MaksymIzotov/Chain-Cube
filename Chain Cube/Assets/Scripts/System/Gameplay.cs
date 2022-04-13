using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public enum STATE
    {
        MENU = 0,
        PLAY = 1
    }

    public static Gameplay Instance;
    private void Awake()
    {
        Instance = this;
    }
    public UnityEvent onGameStart;

    public STATE gameState;
    public int amountOfShotsBeforeAd = 1;

    public int score;
    private int shotsDone;

    public UnityEvent onAdShow;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("IsSaved"))
        {
            PlayerPrefs.SetInt("IsSaved", 0);
            score = 0;
            gameState = STATE.MENU;
        }
        else
        {
            int saved = PlayerPrefs.GetInt("IsSaved");

            if (saved == 1)
            {
                //Load game
                SaveLoad.Instance.LoadData();
                UIHandler.Instance.UpdateScoreText(score);
                StartGame();
            }
            else
            {
                score = 0;
                gameState = STATE.MENU;
                //TODO: Load High Score
            }
        }

        if(PlayerPrefs.HasKey("HighScore"))
            UIHandler.Instance.UpdateHighScoreText(PlayerPrefs.GetInt("HighScore"));
        else
            UIHandler.Instance.UpdateHighScoreText(0);
    }

    public void StartGame()
    {
        onGameStart?.Invoke();

        gameState = STATE.PLAY;
    }

    public void AddScore(int _score)
    {
        score += _score;
        UIHandler.Instance.UpdateScoreText(score);
    }

    public void IncreaseShots()
    {
        shotsDone += 1;

        if (shotsDone % amountOfShotsBeforeAd == 0)
            onAdShow.Invoke();
    }

    public void LoseGame()
    {
        if (!LoseTriggerCheck.Instance.isCubeInside) { return; }

        PlayerPrefs.SetInt("HighScore", score);
        UIHandler.Instance.UpdateHighScoreText(score);

        gameState = STATE.MENU;
        MenuManager.Instance.OpenMenu("restart");

        PlayerPrefs.SetInt("IsSaved", 0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
