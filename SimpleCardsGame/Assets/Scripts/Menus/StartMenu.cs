using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : BaseMenu
{
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
    }

    public void PlayButtonCallback()
    {
        GameController.instance.StartGameplay();
    }
}
