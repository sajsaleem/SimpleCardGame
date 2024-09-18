using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private List<BaseMenu> menuList = new List<BaseMenu>();

    public void Init()
    {
        for(int i =0; i < menuList.Count; i++)
        {
            menuList[i].Init();
        }
    }

    public void ShowMenu(MenuType menuType)
    {
        for(int i = 0; i < menuList.Count; i++)
        {
            if (menuList[i].MenuType == menuType)
            {
                menuList[i].Enable();
                break;
            }
        }
    }

    public void HideMenu(MenuType menuType)
    {
        for (int i = 0; i < menuList.Count; i++)
        {
            if (menuList[i].MenuType == menuType)
            {
                menuList[i].Disable();
                break;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < menuList.Count; i++)
        {
            menuList[i].MyUpdate();
        }
    }
}
