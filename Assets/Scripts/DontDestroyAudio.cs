using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    private static GameObject instance;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }
}