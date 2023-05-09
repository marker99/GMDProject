using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour
{
    //The UI To trigger gameObject dies
    [SerializeField] private GameObject UI;
    //The object that has to die for the UI to trigger
    [SerializeField] private GameObject gameObjectDeathCondition;

    private HealthManager healthManager;

    void Start()
    {
        healthManager = gameObjectDeathCondition.GetComponent<HealthManager>();
        healthManager.IsDead += UICondition;
    }

    private void UICondition()
    {
        UI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}