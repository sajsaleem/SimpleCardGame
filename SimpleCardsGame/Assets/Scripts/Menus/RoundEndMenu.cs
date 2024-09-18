using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundEndMenu : BaseMenu
{
    [SerializeField] private TextMeshProUGUI roundWinnerName;

    public override void Init()
    {
        _canvasGroup ??= GetComponent<CanvasGroup>();
        targetAlpha = 0.0f;
        _canvasGroup.alpha = targetAlpha;
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

        roundWinnerName.text = GameController.instance._gameplayManager.LastRoundWinner.ToString();
        StartCoroutine(_DisableAfterABit());
    }

    private IEnumerator _DisableAfterABit()
    {
        yield return new WaitForSeconds(2);  
        Disable();
        GameController.instance.ResumeGame();
        yield break;
    }
}
