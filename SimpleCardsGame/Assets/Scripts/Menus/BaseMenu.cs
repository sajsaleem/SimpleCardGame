using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MenuType { MainMenu, RoundEnd, GameOver};

public abstract class BaseMenu : MonoBehaviour
{
    protected CanvasGroup _canvasGroup;

    [SerializeField] protected float targetAlpha = 1f;
    [SerializeField] private MenuType _menuType;

    public MenuType MenuType => _menuType;

    public abstract void Init();

    public virtual void MyUpdate()
    {
        
    }

    public virtual void Disable()
    {
        targetAlpha = 0f;
        WaitForUiHide();
    }   
    
    public virtual void Enable()
    {
        gameObject.SetActive(true);
        targetAlpha = 1f;
    }

    private void WaitForUiHide()
    {
        StopCoroutine("WaitForUiHideRoutine");
        StartCoroutine("WaitForUiHideRoutine");
    }


    private IEnumerator WaitForUiHideRoutine()
    {
        yield return new WaitUntil(() => _canvasGroup.alpha <= 0);
        gameObject.SetActive(false);
        yield break;
    }
}
