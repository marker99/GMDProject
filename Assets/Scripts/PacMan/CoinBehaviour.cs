using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.GetScoreManager().IncreaseScore();
            Destroy(gameObject);
        }
        if (other.CompareTag("Wall") || other.CompareTag("PowerUp"))
        {
            ScoreManager.GetScoreManager().RemoveCoin();
            Destroy(gameObject);
        }
    }
}