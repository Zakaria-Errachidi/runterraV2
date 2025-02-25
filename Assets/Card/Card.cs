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
    [SerializeField] private GameObject DescriptionPrefab;




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
}
