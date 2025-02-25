using UnityEngine;

public class BoardLineDisplayer : MonoBehaviour
{
    public void Clean()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
