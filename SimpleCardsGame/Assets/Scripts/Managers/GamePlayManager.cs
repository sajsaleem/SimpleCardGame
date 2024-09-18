using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class GamePlayManager : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private List<BasePlayerController> _players;
    [SerializeField] private GameObject interactionBlocker;
    [SerializeField] private TextMeshProUGUI currentTurnPlayer;
    #endregion

    #region private fields

    private int indexOfDealer = default;
    private bool areCardsDistributed = default;
    private int totalRounds = 0;
    private int roundsPlayed = 1;
    private string lastRoundWinner;
    private string lastGameWinner;
    #endregion

    #region properties

    public string LastRoundWinner => lastRoundWinner;
    public string LastGameWinner => lastGameWinner;

    #endregion

    public void Init()
    {
        totalRounds = GameController.instance._deckManager.DeckCards.Count / _players.Count; // 52/4 => 13 rounds;

        interactionBlocker.SetActive(true);

        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].Init();
        }

        currentTurnPlayer.text = "";
        
    }

    public void StartGameplay()
    {
        indexOfDealer = Random.Range(0, _players.Count);
        GameController.instance._deckManager.ShuffleDeck();
        StartCoroutine(_DistribueCards());
        StartCoroutine(_StartGameplay());
    }

    private IEnumerator _DistribueCards()
    {
        int currentPlayerIndex = indexOfDealer;
        List<CardData> deck = GameController.instance._deckManager.DeckCards;//ReferencesManager.instance._deckManager.DeckCards;

        for (int i = 0; i < deck.Count; i++)
        {
            BasePlayerController _playerController = _players[currentPlayerIndex];
            deck[i]._playerIndex = currentPlayerIndex;
            _playerController.ReceivedCard(deck[i]);
            currentPlayerIndex = (currentPlayerIndex - 1 + _players.Count) % _players.Count;
            yield return new WaitForSeconds(0.1f);
        }

        areCardsDistributed = true;

        for (int i = 0; i < _players.Count; i++)
        {
            if (_players[i].isBot)
                _players[i].SortOutCards();
        }

        yield break;
    }

    private IEnumerator _StartGameplay()
    {
        yield return new WaitUntil(() => areCardsDistributed);

        yield return new WaitForSeconds(0.2f);

        int currentPlayerIndex;

        while (roundsPlayed <= totalRounds)
        {
            currentPlayerIndex = indexOfDealer;

            for (int i = 0; i < _players.Count; i++)
            {
                if (_players[currentPlayerIndex].isBot)
                {
                    interactionBlocker.SetActive(true);
                    _players[currentPlayerIndex].PlayBotCard();
                }
                else
                {
                    interactionBlocker.SetActive(false);
                }

                currentTurnPlayer.text = _players[currentPlayerIndex].nameText.text;

                yield return new WaitUntil(() => _players[currentPlayerIndex].isCardPlayed);
                currentPlayerIndex = (currentPlayerIndex - 1 + _players.Count) % _players.Count;
                yield return new WaitForSeconds(0.2f);
            }

            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ResetHandForRoundEnd();
            }

            roundsPlayed++;

            CardData _card = GameController.instance._playAreaManager.GetHighestPlaced();
            lastRoundWinner = _players[_card._playerIndex].nameText.text;
            GameController.instance.ShowRoundEnd();

            yield return new WaitUntil(() => GameController.instance.GameState == GameStates.STARTGAMEPLAY);
            _players[_card._playerIndex].UpdateWinCount();

            GameController.instance._playAreaManager.ResetArea();
        }

        int maxPoints = _players.Max(player => player.WinsCount);

        BasePlayerController gameWinner = _players.FirstOrDefault(player => player.WinsCount == maxPoints);
        lastGameWinner = gameWinner.nameText.text;
        GameController.instance.ShowGameOver();

        //Debug.Log("<color=green> Game End </color>");

        yield break;
    }
}
