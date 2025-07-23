using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PopupBoxCheck : PopupUI
{
    private RectTransform rectTransform;

    [SerializeField] private GiftBox giftBox;
    [SerializeField] private BoxSlider boxSlider;
    
    [SerializeField] private List<CanvasGroup> parentCanvasGroups;
    [SerializeField] private CanvasGroup childCanvasGroup;

    [Space]
    [Tooltip("팝업UI 움직임 시간 조절")]
    [SerializeField, Range(0.1f, 2f)] private float doMoveYDuration;

    private void Awake()
    {
        boxSlider.SlideAction += FadeEffect;
    }

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

    private void OnCompleteOpen()
    {
        giftBox.AppearGiftBox();
        boxSlider.Init();
    }

    private void FadeEffect(float deltaY)
    {
        float parentAlpha = Mathf.InverseLerp(465f, 0f, deltaY);
        float childAlpha = Mathf.InverseLerp(930f, 0f, deltaY);

        foreach (var canvasGroup in parentCanvasGroups)
        {
            canvasGroup.alpha = parentAlpha;
        }
        
        childCanvasGroup.alpha = childAlpha;
    }

    protected override void Open()
    {
        rectTransform.DOMoveY(Screen.height / 2f, doMoveYDuration).OnComplete(OnCompleteOpen);
    }

    protected override void Close()
    {
    }
}