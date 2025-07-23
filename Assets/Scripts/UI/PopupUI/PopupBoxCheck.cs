using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PopupBoxCheck : PopupUI
{
    private RectTransform rectTransform;

    [SerializeField] private GiftBox giftBox;
    [SerializeField] private BoxSlider boxSlider;

    [Space]
    [Tooltip("팝업UI 움직임 시간 조절")]
    [SerializeField, Range(0.1f, 2f)] private float doMoveYDuration;

    private IEnumerator Start()
    {
        rectTransform = transform as RectTransform;
        if (rectTransform != null)
        {
            rectTransform.transform.position = new Vector2(rectTransform.transform.position.x, -Screen.height / 2f);
        }
        yield return new WaitForSeconds(0.5f);
        Open();
    }

    protected override void Open()
    {
        rectTransform.DOMoveY(Screen.height / 2f, doMoveYDuration).OnComplete(giftBox.AppearGiftBox);
    }

    protected override void Close()
    {
    }
}