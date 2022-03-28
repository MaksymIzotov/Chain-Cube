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

    public void UpdateScoreText(int _score) => score.text = _score.ToString();
}
