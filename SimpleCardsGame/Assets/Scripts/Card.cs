using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private CardData _cardData;
    private int index = 0;
    private BasePlayerController _playerController;
    private RawImage _rawImage;

    public CardData CardData { get => _cardData; set => _cardData = value; }

    public void Init(BasePlayerController playerController, int i)
    {
        this._playerController = playerController;
        index = i;
        _rawImage = GetComponent<RawImage>();
    }

    public void OnClickCallback()
    {
        _playerController.CardClicked(this);
    }

    public void SetImageTexture(Texture _texture)
    {
        _rawImage ??= GetComponent<RawImage>();
        _rawImage.texture = _texture;
    }

    public void SetActiveStatus(bool value)
    {
        gameObject.SetActive(value);
    }
}
