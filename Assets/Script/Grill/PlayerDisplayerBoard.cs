using UnityEngine;
using UnityEngine.UI;

public class PlayerDisplayerBoard : MonoBehaviour
{
    public VerticalLayoutGroup VerticalLayoutGroup;
    public BoardLineDisplayer PrefabBoardLineDisplayer;
    public BoardInsetDisplayer PrefabBoardInsetDisplayer;
    public void init(int cptligne, int col)
    {
        cleangroup();
        for (int i = 0; i < cptligne; i++)
        {
            BoardLineDisplayer board = Instantiate(PrefabBoardLineDisplayer, VerticalLayoutGroup.transform);
            board.Clean();

            for (int j = 0; j < col; j++)
            {
                BoardInsetDisplayer insetDisplayer = Instantiate(PrefabBoardInsetDisplayer, board.transform);
            }
        }
    }
    void cleangroup()
    {
        foreach (Transform child in VerticalLayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
