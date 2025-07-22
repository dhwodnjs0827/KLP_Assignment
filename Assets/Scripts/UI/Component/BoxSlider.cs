using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoxSlider : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform rectTransform;
    private Rect inputFieldRect;
    
    private bool canDrag;
    private Vector2 startMousePos;
    private Vector2 anchoredPos;
    
    private const float SLIDE_DURATION = 0.5f;
    private const float SLIDE_THRESHOLD = 400f;

    private void Awake()
    {
        inputFieldRect = UIRectCalculate.RectInfo(rectTransform);
        canDrag = false;
        anchoredPos = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 mousePos = eventData.position;
        if (UIRectCalculate.IsInRect(inputFieldRect, mousePos))
        {
            canDrag = true;
            startMousePos = mousePos;
            //anchoredPos = rectTransform.anchoredPosition;
        }
        else
        {
            canDrag = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!canDrag)
        {
            return;
        }
        
        float dragY = eventData.position.y - startMousePos.y;
        if (dragY > 0)
        {
            rectTransform.anchoredPosition = anchoredPos + new Vector2(0, dragY);
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        canDrag = false;
        float totalDragY = rectTransform.anchoredPosition.y - anchoredPos.y;

        if (totalDragY >= SLIDE_THRESHOLD)
        {
            // 슬라이드 업 연출
            rectTransform.DOAnchorPosY(anchoredPos.y + 1000f, SLIDE_DURATION)
                .SetEase(Ease.OutCubic);
        }
        else
        {
            // 원래 위치로 복귀
            rectTransform.DOAnchorPos(anchoredPos, SLIDE_DURATION)
                .SetEase(Ease.OutQuad);
        }
    }
}
