using UnityEngine;

public class Arrangement : MonoBehaviour
{
    public PlayerDisplayerBoard P1DisplayerBoard;
    public PlayerDisplayerBoard P2DisplayerBoard;
    public int cptligne = 3;
    public int cptcol = 3;
    void Start()
    {
        P1DisplayerBoard.init(cptligne, cptcol);
        P2DisplayerBoard.init(cptligne, cptcol);
    }
}
