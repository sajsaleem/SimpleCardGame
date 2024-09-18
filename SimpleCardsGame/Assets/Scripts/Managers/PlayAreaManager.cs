using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayAreaManager : MonoBehaviour
{
    [SerializeField] private List<Card> playAreaCards;
    [SerializeField] private int maxCardsPerRound = default;
    private int placedCardsCounter = default;

    public void PlaceACard(CardData card)
    {
        if (ReachedMaxPlacedCards())
            return;

        playAreaCards[placedCardsCounter].SetImageTexture(card.cardTexture);
        playAreaCards[placedCardsCounter].gameObject.SetActive(true);
        playAreaCards[placedCardsCounter].CardData = card;
        placedCardsCounter++;
    }

    public CardData GetHighestPlaced()
    {
        CardData winningCard = playAreaCards[0].CardData;

        for(int i = 1; i < playAreaCards.Count; i++)
        {
            CardData currentCard = playAreaCards[i].CardData;

            if(currentCard.rank > winningCard.rank || (currentCard.rank == winningCard.rank && currentCard.value > winningCard.value))
                winningCard = currentCard;
        }

        return winningCard;
    }

    public bool ReachedMaxPlacedCards()
    {
        return placedCardsCounter >= maxCardsPerRound;
    }

    public void ResetArea()
    {
        for(int i = 0; i < playAreaCards.Count; i++)
        {
            playAreaCards[i].CardData = null;
            playAreaCards[i].SetActiveStatus(false);

        }

        placedCardsCounter = 0;
    }
}
