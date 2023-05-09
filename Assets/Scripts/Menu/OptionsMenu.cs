using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;
    /*ublic AudioSource audioSource;*/

    [SerializeField]
    private Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("gameVolume"))
        {
            PlayerPrefs.SetFloat("gameVolume", 0.5f);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void SetVolume(float volume)
    {
        //audioMixer.SetFloat("volume", volume);
        //audioSource.volume = volume;

        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("gameVolume", volumeSlider.value);
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("gameVolume");
    }


    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

}