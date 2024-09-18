using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Threading.Tasks;
//using System;

public class BotController : BasePlayerController
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void ReceivedCard(CardData card)
    {
        base.ReceivedCard(card);
    }

    public override void ThrowACard(CardData card)
    {
        base.ThrowACard(card);
    }

    public override void SortOutCards()
    {
        base.SortOutCards();

        //sort by rank(ascending) using OrderBy
        CardsInHand.OrderBy(card => card.rank);
    }

    public override async void PlayBotCard()
    {
        base.PlayBotCard();

        await Task.Delay(2000);

        float value = Random.value;
        int randomIndex;

        if (value >= 0.5)
        {
            randomIndex = Random.Range(CardsInHand.Count / 2, CardsInHand.Count);
        }
        else
        {
            randomIndex = Random.Range(0, CardsInHand.Count / 2);

        }
        ThrowACard(CardsInHand[randomIndex]);
        CardsInHand.Remove(CardsInHand[randomIndex]);
        cardsText.text = CardsInHand.Count.ToString();
    }

    public override void ResetHandForRoundEnd()
    {
        base.ResetHandForRoundEnd();
    }

    public override void UpdateWinCount()
    {
        base.UpdateWinCount();
    }
}
