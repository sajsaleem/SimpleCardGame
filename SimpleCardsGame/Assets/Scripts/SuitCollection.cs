using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardSuit Collection", menuName = "Create New CardSuit Collection")]
public class SuitCollection : ScriptableObject
{
    [field: SerializeField] public List<CardData> data { get; private set; }
    [field: SerializeField] public CardSuit suit { get; private set; }
}
