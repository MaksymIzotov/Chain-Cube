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

    private int score;
    private int shotsDone;

    public UnityEvent onAdShow;

    private void Start()
    {
        score = 0;
        gameState = STATE.MENU;
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

        gameState = STATE.MENU;
        MenuManager.Instance.OpenMenu("restart");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
