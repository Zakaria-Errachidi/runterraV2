using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool IsYourTurn;
    public int YourTurn;
    public int IsOpponentTurn;
    public TMP_Text TurnText;

    public int MaxMana;
    public int CurrentMana;
    public TMP_Text MancheText;
    void Start()
    {
        IsYourTurn = true;
        YourTurn = 1;
        IsOpponentTurn = 0;

        MaxMana = 1;
        CurrentMana = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsYourTurn == true)
        {
            TurnText.text = "Your Turn";
        }
        else
        {
            TurnText.text = "Opponent Turn";
        }
        //MancheText.text = CurrentMana + "/" + MaxMana;
    }

    public void EndYourTurn()
    {
        IsYourTurn = false;
        IsOpponentTurn++;
    }
    public void EndOpponentTurn()
    {
        IsYourTurn = true;
        YourTurn++;
        MaxMana++;
        CurrentMana = MaxMana;
    }
}
