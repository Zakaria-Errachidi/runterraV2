using UnityEngine;
using UnityEngine.SceneManagement;

public class surrendre : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LeaveGame()
    {
        Debug.Log("Quitter la partie ...");
        SceneManager.LoadSceneAsync("Start");
    }
}
