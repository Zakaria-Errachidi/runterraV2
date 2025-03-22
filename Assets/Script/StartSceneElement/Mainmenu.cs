using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject volumeCanvas;

    public void PlayGame()
    {
        Debug.Log("Chargement du jeu...");
        SceneManager.LoadSceneAsync("SampleScene");
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

    public void QuitGame()
    {
        Debug.Log(" Quitter !");
        Application.Quit();
    }
}
