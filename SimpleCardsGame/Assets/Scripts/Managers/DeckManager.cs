using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<SuitCollection> allCards;

    private List<CardData> deckCards = new List<CardData>();

    public List<CardData> DeckCards => deckCards;

    public void InitializeDeck()
    {
        if (deckCards.Count >= 52)
            return;

        for(int i = 0; i < allCards.Count; i++)
        {
            for (int j = 0; j < allCards[i].data.Count; j++)
            {
                deckCards.Add(allCards[i].data[j]);
            }
        }
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deckCards.Count; i++)
        {
            CardData temp = deckCards[i];
            int randomIndex = Random.Range(i, deckCards.Count);
            deckCards[i] = deckCards[randomIndex];
            deckCards[randomIndex] = temp;
        }
    }
}
