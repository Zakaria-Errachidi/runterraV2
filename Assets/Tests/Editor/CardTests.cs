using NUnit.Framework;
using UnityEngine;

public class CardTests
{
    private Card card;
    private Card targetCard;
    private CardDefinition cardDef;

    [SetUp]
    public void Setup()
    {
        GameObject cardObject = GameObject.Instantiate(Resources.Load<GameObject>("CardPrefab"));
        GameObject targetObject = GameObject.Instantiate(Resources.Load<GameObject>("CardPrefab"));

        Assert.IsNotNull(cardObject, "Erreur : CardPrefab n'a pas pu être chargé.");
        Assert.IsNotNull(targetObject, "Erreur : CardPrefab cible n'a pas pu être chargé.");

        card = cardObject.GetComponent<Card>();
        targetCard = targetObject.GetComponent<Card>();

        Assert.IsNotNull(card, "Erreur : Le script Card n'est pas attaché à CardPrefab.");
        Assert.IsNotNull(targetCard, "Erreur : Le script Card n'est pas attaché à CardPrefab cible.");

        cardDef = ScriptableObject.CreateInstance<CardDefinition>();
        cardDef.cardName = "Test Card";
        cardDef.health = 10;
        cardDef.damage = 5;
        cardDef.mana = 2;

        card.Initialize(cardDef);
        targetCard.Initialize(cardDef);
    }

    [TearDown]
    public void Teardown()
    {
        GameObject.DestroyImmediate(card.gameObject);
        GameObject.DestroyImmediate(targetCard.gameObject);
    }

    [Test]
    public void Card_TakeDamage()
    {
        card.TakeDamage(3);
        Assert.AreEqual(7, card.GetHealth(), "Erreur : La carte aurait dû avoir 7 HP après 3 dégâts.");

        card.TakeDamage(10);
        Assert.AreEqual(0, card.GetHealth(), "Erreur : La carte aurait dû tomber à 0 HP.");
    }

    [Test]
    public void Card_DoDamage()
    {
        card.Attack(targetCard);
        Assert.AreEqual(5, targetCard.GetHealth(), "Erreur : La cible aurait dû perdre 5 HP.");
    }

    [Test]
    public void Card_CanRevive()
    {
        card.TakeDamage(10);
        Assert.AreEqual(0, card.GetHealth(), "Erreur : La carte aurait dû avoir 0 HP après l'attaque.");

        card.Revive();
        Assert.AreEqual(5, card.GetHealth(), "Erreur : La carte aurait dû être réanimée avec 5 HP.");
    }
}
