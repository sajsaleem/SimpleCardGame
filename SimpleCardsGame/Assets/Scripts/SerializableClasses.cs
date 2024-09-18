using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardData
{
    public Texture cardTexture;
    public int value = default; // this is the card value like 2,3,4,5,6,7,8,9, 10 , 11(Joker) , 12(Queen) , 13(King), 14(ACE);
    public int rank = default; // this is rank of card suit, Highest Spades(4) , Lowest clubs(1);
    public int _playerIndex = -1;
}

public enum CardSuit { Club, Diamond, Heart, Spades};
public enum GameStates { MENU, STARTGAMEPLAY,GAMEEND, PAUSED};
