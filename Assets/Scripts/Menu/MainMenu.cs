using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("gameVolume"))
        {
            PlayerPrefs.SetFloat("gameVolume", 0.5f);
            LoadAudio();
        }
        else
        {
            LoadAudio();
        }
    }

    public void PlayPacMan3D()
    {
        SceneManager.LoadScene("Pac-Man");
    }

    public void PlayPacAttack()
    {
        SceneManager.LoadScene("PAC-ATTACK");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void LoadAudio()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("gameVolume");
    }
}