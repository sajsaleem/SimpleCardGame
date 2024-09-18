using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : BaseMenu
{
    [SerializeField] private TextMeshProUGUI _winnerText;

    public override void Init()
    {
        _canvasGroup ??= GetComponent<CanvasGroup>();
        targetAlpha = 0.0f;
    }

    public override void MyUpdate()
    {
        base.MyUpdate();

        float t = Mathf.MoveTowards(_canvasGroup.alpha, targetAlpha, 5 * Time.deltaTime);
        _canvasGroup.alpha = t;
    }

    public override void Disable()
    {
        base.Disable();
    }

    public override void Enable()
    {
        base.Enable();
        _winnerText.text = GameController.instance._gameplayManager.LastGameWinner.ToString();
    }

    public void ReplayCallback()
    {
        GameController.instance.ReloadScene();
    }
}
