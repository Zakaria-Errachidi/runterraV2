using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private TMP_Text ManaCost;
    [SerializeField] private TMP_Text DamageText;
    [SerializeField] private TMP_Text HpCard;
    [SerializeField] private VerticalLayoutGroup DescriptionContainer;
    [SerializeField] private TMP_Text Cardname;
    [SerializeField] private Image DescriptionBackground;
    [SerializeField] private Image CardImage;
    [SerializeField] private Image NameBackground;
    [SerializeField] private Image CardBackground;
    [SerializeField] private GameObject DescriptionPrefab;
    [SerializeField] private Sprite defaultCardBackground;
    private CardDefinition cardDefinition;

    private int currentHealth;
    private int playerIndex;

    public void Initialize(CardDefinition cardDefinition)
    {
        if (cardDefinition == null)
        {
            Debug.LogError("Erreur : CardDefinition est null lors de l'initialisation !");
            return;
        }

        currentHealth = cardDefinition.health;

        if (ManaCost != null) ManaCost.text = cardDefinition.mana.ToString();
        if (DamageText != null) DamageText.text = cardDefinition.damage.ToString();
        if (HpCard != null) HpCard.text = currentHealth.ToString();
        if (Cardname != null) Cardname.text = cardDefinition.cardName;
        if (CardImage != null) CardImage.sprite = cardDefinition.cardImage;

        if (CardBackground != null)
            CardBackground.sprite = cardDefinition.cardbackground != null ? cardDefinition.cardbackground : defaultCardBackground;
        if (DescriptionBackground != null) DescriptionBackground.sprite = cardDefinition.descriptionbackground;
        if (NameBackground != null) NameBackground.sprite = cardDefinition.namebackground;
        if (!Application.isPlaying) return;

        if (DescriptionContainer != null && DescriptionPrefab != null)
        {
            foreach (Transform child in DescriptionContainer.transform)
            {
                Destroy(child.gameObject);
            }

            foreach (string descriptionLine in cardDefinition.description)
            {
                GameObject newTextObject = Instantiate(DescriptionPrefab, DescriptionContainer.transform);
                TMP_Text newText = newTextObject.GetComponentInChildren<TMP_Text>();

                if (newText != null)
                {
                    newText.text = descriptionLine;
                }
            }
        }

    }
    public CardDefinition GetCardDefinition()
    {
        return cardDefinition;
    }

    public int GetManaCost()
    {
        return int.Parse(ManaCost.text);
    }

    public int GetDamage()
    {
        return int.Parse(DamageText.text);
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);
        if (HpCard != null) HpCard.text = currentHealth.ToString();
    }

    public void SetPlayerIndex(int index)
    {
        playerIndex = index;
    }

    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void Attack(Card target)
    {
        if (target == null) return;
        target.TakeDamage(GetDamage());
    }

    public void Revive()
    {
        int reviveHealth = 5;
        currentHealth = reviveHealth;
        if (HpCard != null) HpCard.text = reviveHealth.ToString();
        Debug.Log($"{Cardname.text} a été ressuscitée avec {reviveHealth} HP !");
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
