using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panels")]
    public GameObject mainMenuCanvas;
    public GameObject volumeCanvas;

    [Header("Audio Settings")]
    public AudioSource backgroundMusic;
    public Slider volumeSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Garde l'UI et l'audio entre les scènes
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        backgroundMusic.volume = savedVolume;

        if (volumeSlider != null)
        {
            volumeSlider.value = savedVolume;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void PlayGame()
    {
        Debug.Log("Chargement du jeu...");
        if (AudioManager.Instance != null)
        {
            Debug.Log("La musique continue entre les scènes.");
        }
        else
        {
            Debug.LogError(" AudioManager est perdu lors du changement de scène !");
        }

        SceneManager.LoadSceneAsync("SampleScene");
    }


    public void QuitGame()
    {
        Debug.Log("Quitter !");
        Application.Quit();
    }

    public void OpenVolumeSettings()
    {
        mainMenuCanvas.SetActive(false);
        volumeCanvas.SetActive(true);
    }

    public void CloseVolumeSettings()
    {
        volumeCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
*/