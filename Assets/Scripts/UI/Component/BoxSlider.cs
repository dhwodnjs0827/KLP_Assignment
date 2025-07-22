using UnityEngine;
using UnityEngine.EventSystems;

public class BoxSlider : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private RectTransform rectTransform;
    private Rect inputFieldRect;
    
    private bool canDrag;
    private Vector2 startMousePos;
    private Vector2 anchoredPos;

    private void Awake()
    {
        inputFieldRect = UIRectCalculate.RectInfo(rectTransform);
        canDrag = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 mousePos = eventData.position;
        if (UIRectCalculate.IsInRect(inputFieldRect, mousePos))
        {
            canDrag = true;
            startMousePos = mousePos;
            anchoredPos = rectTransform.anchoredPosition;
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
        Vector2 mousePos = eventData.position;
        Vector2 sliderPos = new Vector2(gameObject.transform.position.x, mousePos.y);
    }
}
