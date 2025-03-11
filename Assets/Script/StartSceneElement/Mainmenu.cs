using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("it works");
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void QuitGame()
    {
        Debug.Log("Quitter!");
        Application.Quit();
    }
}
