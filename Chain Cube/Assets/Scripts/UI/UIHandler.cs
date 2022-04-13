using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance;
    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text highScore;

    public void UpdateScoreText(int _score) => score.text = _score.ToString();

    public void UpdateHighScoreText(int _score) => highScore.text = "High score: " + _score.ToString();
}
