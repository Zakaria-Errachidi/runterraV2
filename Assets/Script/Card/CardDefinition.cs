using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "CardDefinition", menuName = "Scriptable Objects/CardDefinition")]
public class CardDefinition : ScriptableObject
{
    public string cardName;
    public string[] description;
    public int health;
    public int damage;
    public int mana;
    public Sprite descriptionbackground;
    public Sprite cardImage;
    public Sprite namebackground;
    public Sprite cardbackground;
    public bool isChampion;
}
