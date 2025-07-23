using System;
using DG.Tweening;
using UnityEngine;

public class PopupReceiveProduct : PopupUI
{
    [SerializeField] RectTransform rect;
    
    private void Start()
    {
        Open();
    }

    protected override void Open()
    {
        rect.DOMoveY(0f, 1f);
    }

    protected override void Close()
    {
    }
}
