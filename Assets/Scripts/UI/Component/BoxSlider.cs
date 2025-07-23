using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxSlider : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform inputField;
    private Rect inputFieldRect;

    [SerializeField] RectMask2D rectMask;

    private bool canDrag;
    private Vector2 startMousePos;
    private Vector2 anchoredPos;
    private float anchoredDeltaY;

    private const float SLIDE_DURATION = 0.5f;
    private const float SLIDE_THRESHOLD = 400f;

    public event Action<float> SlideAction;
    public event Action OpenAction;

    private void Awake()
    {
        canDrag = false;
        SlideAction += MaskEffect;
    }

    public void Init()
    {
        inputFieldRect = UIRectCalculate.RectInfo(inputField);
        anchoredPos = rectTransform.anchoredPosition;
    }

    private void MaskEffect(float deltaY)
    {
        rectMask.padding = new Vector4(rectMask.padding.x, deltaY, rectMask.padding.z, rectMask.padding.w);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 mousePos = eventData.position;
        if (UIRectCalculate.IsInRect(inputFieldRect, mousePos))
        {
            Debug.Log("드래그 가능");
            canDrag = true;
            startMousePos = mousePos;
        }
        else
        {
            Debug.Log("드래그 불가능");
            canDrag = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag)
        {
            return;
        }

        // 드래그한 정도 값
        float dragY = eventData.position.y - startMousePos.y;
        if (dragY > 0)
        {
            rectTransform.anchoredPosition = anchoredPos + new Vector2(0, dragY);
            anchoredDeltaY = rectTransform.anchoredPosition.y - anchoredPos.y;
            
            SlideAction?.Invoke(anchoredDeltaY);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        canDrag = false;
        float totalDragY = rectTransform.anchoredPosition.y - anchoredPos.y;

        if (totalDragY >= SLIDE_THRESHOLD)
        {
            // 슬라이드 업 연출
            rectTransform.DOAnchorPosY(anchoredPos.y + 930f, SLIDE_DURATION)
                .SetEase(Ease.OutCubic);
            
            DOTween.To(() => rectTransform.anchoredPosition.y, x => SlideAction?.Invoke(x), 930f, SLIDE_DURATION)
                .SetEase(Ease.OutCubic);
            
            OpenAction?.Invoke();
        }
        else
        {
            // 원래 위치로 복귀
            rectTransform.DOAnchorPos(anchoredPos, SLIDE_DURATION)
                .SetEase(Ease.OutQuad);
            
            DOTween.To(() => rectTransform.anchoredPosition.y, x => SlideAction?.Invoke(x), 0f, SLIDE_DURATION)
                .SetEase(Ease.OutQuad);
        }
    }
}