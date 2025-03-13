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




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void initialize(CardDefinition cardDefinition)
    {
        // Mise à jour des valeurs principales de la carte
        ManaCost.text = cardDefinition.mana.ToString();
        DamageText.text = cardDefinition.damage.ToString();
        HpCard.text = cardDefinition.health.ToString();
        DescriptionBackground.sprite = cardDefinition.descriptionbackground;
        Cardname.text = cardDefinition.cardName;
        CardImage.sprite = cardDefinition.cardImage;

        CardBackground.sprite = cardDefinition.cardbackground != null ? cardDefinition.cardbackground : defaultCardBackground;
        DescriptionBackground.sprite = cardDefinition.descriptionbackground;
        NameBackground.sprite = cardDefinition.namebackground;



        // Ajoute dynamiquement chaque ligne de description
        foreach (string descriptionLine in cardDefinition.description)
        {
            if (DescriptionPrefab != null)
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

    public int GetManaCost()
    {
        return int.Parse(ManaCost.text); // Convertit le texte TMP en int
    }
    public int GetDamage()
    {
        return int.Parse(DamageText.text); // Récupère les dégâts de la carte
    }

    public int GetHealth()
    {
        return int.Parse(HpCard.text); // Récupère les HP de la carte
    }

    public void TakeDamage(int damage)
    {
        int newHealth = Mathf.Max(0, GetHealth() - damage);
        HpCard.text = newHealth.ToString(); // Met à jour l'affichage des HP
    }



}
