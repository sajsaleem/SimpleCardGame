 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [field: SerializeField] public GamePlayManager _gameplayManager { get; private set; }
    [field: SerializeField] public PlayAreaManager _playAreaManager { get; private set; }
    [field: SerializeField] public DeckManager _deckManager { get; private set; }
    [field: SerializeField] public MenuController _menuController { get; private set; }
    [field: SerializeField] public GameObject gameplayGroup { get; private set; }

    private GameStates _gameState;

    public GameStates GameState => _gameState;

    private void Awake()
    {
        if(instance ==  null)
            instance = this;

        _deckManager.InitializeDeck();
        _gameplayManager.Init();
        _menuController.Init();
    }

    private void Start()
    {
        gameplayGroup.SetActive(false);

        if(_menuController != null)
        {
            _menuController.ShowMenu(MenuType.MainMenu);
        }
        _gameState = GameStates.MENU;
    }

    public void StartGameplay()
    {
        gameplayGroup.SetActive(true);

        if (_menuController != null)
        {
            _menuController.HideMenu(MenuType.MainMenu);
        }

        if (_gameplayManager != null)
        {
            _gameplayManager.StartGameplay();
        }
        _gameState = GameStates.STARTGAMEPLAY;
    }

    public void ShowRoundEnd()
    {
        if (_menuController != null)
        {
            _menuController.ShowMenu(MenuType.RoundEnd);
        }
        _gameState |= GameStates.PAUSED;
    }

    public void ShowGameOver()
    {
        if(_menuController != null)
        {
            _menuController.ShowMenu(MenuType.GameOver);
        }
    }

    public void ResumeGame()
    {
        _gameState = GameStates.STARTGAMEPLAY;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
