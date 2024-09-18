using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : BasePlayerController
{
    [SerializeField] private int maxCardsInHand = 0;
    [SerializeField] private GameObject parentOfCardsPanel;
    [SerializeField] private GameObject cardPrefab;
    private List<Card> cards = new List<Card>();
    private int cardAddCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public override void Init()
    {
        base.Init();

        //Debug.Log("PlayController init called");

        for (int i = 0; i < maxCardsInHand; i++)
        {
            GameObject newCard = Instantiate(cardPrefab);
            newCard.transform.parent = parentOfCardsPanel.transform;
            newCard.transform.localScale = Vector3.one;
            cards.Add(newCard.GetComponent<Card>());
            newCard.gameObject.SetActive(false);
        }

        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Init(this, i);
        }
    }

    public override void ResetHandForRoundEnd()
    {
        base.ResetHandForRoundEnd();
    }

    public override void ReceivedCard(CardData card)
    {
        base.ReceivedCard(card);
        cards[cardAddCounter].SetImageTexture(card.cardTexture);
        cards[cardAddCounter].SetActiveStatus(true);
        cards[cardAddCounter].CardData = card;
        cards[cardAddCounter].transform.localPosition = Vector3.zero;
        cardAddCounter++;
        cardAddCounter = Mathf.Clamp(cardAddCounter, 0, cards.Count - 1);
    }

    public override void CardClicked(Card _card)
    {
        base.CardClicked(_card);

        //throw a card to play area;
        ThrowACard(_card.CardData);
        CardsInHand.Remove(_card.CardData);
        _card.gameObject.SetActive(false);
    }

    public override void ThrowACard(CardData card)
    {
        base.ThrowACard(card);

    }

    public override void UpdateWinCount()
    {
        base.UpdateWinCount();
    }
}
