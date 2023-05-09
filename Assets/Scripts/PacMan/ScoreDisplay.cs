using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI CoinsLeftText;
    
    public delegate void WinCondition();
    public event WinCondition GameWon;

    void Start()
    {
        UpdateScore(0);
    }

    private void OnEnable()
    {
        ScoreManager.GetScoreManager().ScoreNotifier += UpdateScore;
        ScoreManager.GetScoreManager().OnCoinsChanged += UpdateCoinsLeft;
    }
    
    private void OnDisable()
    {
        ScoreManager.GetScoreManager().ScoreNotifier -= UpdateScore;
        ScoreManager.GetScoreManager().OnCoinsChanged -= UpdateCoinsLeft;
    }
    
    private void UpdateScore(int score)
    {
        ScoreText.text = $"Score: {score}\n";
    }

    private void UpdateCoinsLeft(int coinsLeft)
    {
        CoinsLeftText.text = $"Coins Left: {coinsLeft}";
        if (coinsLeft == 0)
            GameWon?.Invoke();
    }
}