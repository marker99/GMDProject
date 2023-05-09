using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class WinScript : MonoBehaviour
{

    //The UI To trigger gameObject dies
    [SerializeField] private GameObject UI;
    
    [SerializeField] private GameObject WinConditionObject;

    private ScoreDisplay scoreDisplay;

    void Start()
    {
        scoreDisplay = WinConditionObject.GetComponent<ScoreDisplay>();
        scoreDisplay.GameWon += UICondition;
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
