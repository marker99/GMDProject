public class ScoreManager
{
    private int coinsLeft = 0;
    private int score = 0;
    private static ScoreManager scoreManager;

    public delegate void ScoreListener(int score);
    public ScoreListener ScoreNotifier;
    
    public delegate void CoinsChanged(int coinsLeft);
    public CoinsChanged OnCoinsChanged;
    
    private ScoreManager()
    {

    }
    public static ScoreManager GetScoreManager()
    {
        if (scoreManager == null)
        {
            scoreManager = new ScoreManager();
        }

        return scoreManager;
    }
    
    public void AddCoin()
    {
        coinsLeft++;
        OnCoinsChanged?.Invoke(coinsLeft);
    }
    
    public void IncreaseScore()
    {
        score++;
        RemoveCoin();
        ScoreNotifier?.Invoke(score);
    }

    public void RemoveCoin()
    {
        coinsLeft--;
        OnCoinsChanged?.Invoke(coinsLeft);
    }
    
    public void Reset()
    {
        coinsLeft = 0;
        score = 0;
    }
}