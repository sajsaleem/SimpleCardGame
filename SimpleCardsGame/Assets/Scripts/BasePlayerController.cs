using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BasePlayerController : MonoBehaviour
{
    public int totalCardsInHand => cardsInHand.Count;
    public List<CardData> CardsInHand => cardsInHand;

    [HideInInspector] public bool isCardPlayed = default;

    [field: SerializeField] public bool isBot { get; private set; } = default;
    [field: SerializeField] public TextMeshProUGUI cardsText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI _winsText { get; private set; }
    [field: SerializeField] public TextMeshProUGUI nameText { get; private set; }


    private List<CardData> cardsInHand = new List<CardData>();
    private int winsCount = 0;

    public int WinsCount => winsCount;

    public virtual void Init()
    {
        _winsText.text = winsCount.ToString();
    }

    public virtual void ReceivedCard(CardData card)
    {
        //Debug.LogFormat("CardName: {0} , player: {1}", card.cardTexture.name, card._playerIndex);

        cardsInHand.Add(card);

        if (cardsText != null)
            cardsText.text = CardsInHand.Count.ToString();
    }

    public virtual void ThrowACard(CardData card)
    {
        GameController.instance._playAreaManager.PlaceACard(card);
        isCardPlayed = true;
    }

    public virtual void CardClicked(Card _card)
    {

    }

    public virtual void ResetHandForRoundEnd()
    {
        isCardPlayed = false;
    }

    public virtual void ResetForGameEnd()
    {

    }

    public virtual void UpdateWinCount()
    {
        winsCount++;

        if(_winsText != null)
            _winsText.text = winsCount.ToString();
    }

    public virtual void SortOutCards()
    {

    }

    public virtual void PlayBotCard()
    {

    }
}
