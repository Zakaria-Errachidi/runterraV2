using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public CardDefinition[] Cards;
    public CardDefinition PickRandom()
    {
        return Cards[Random.Range(0, Cards.Length)];
    }

}
