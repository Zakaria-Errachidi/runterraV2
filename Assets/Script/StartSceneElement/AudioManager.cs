using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource backgroundMusic;
    public Slider volumeSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("AudioManager persistant après changement de scène.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("AudioManager déjà existant, suppression...");
        }
    }


    private void Start()
    {
        // Trouve automatiquement l'AudioSource s'il est manquant
        if (backgroundMusic == null)
        {
            backgroundMusic = GetComponent<AudioSource>();
            if (backgroundMusic == null)
            {
                Debug.LogError("Aucun AudioSource trouvé sur AudioManager !");
                return;
            }
        }

        // Charge le volume enregistré
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        backgroundMusic.volume = savedVolume;
        backgroundMusic.loop = true;
        backgroundMusic.Play();

        // Si le volumeSlider est dans la scène, l'attacher automatiquement
        if (volumeSlider == null)
        {
            volumeSlider = FindObjectOfType<Slider>();
            if (volumeSlider != null)
            {
                volumeSlider.value = savedVolume;
                volumeSlider.onValueChanged.AddListener(SetVolume);
            }
        }
    }


    public void SetVolume(float volume)
    {
        backgroundMusic.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }
}
