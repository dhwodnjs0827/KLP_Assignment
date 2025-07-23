using DG.Tweening;
using UnityEngine;

public class GiftBox : MonoBehaviour
{
    private RectTransform rectTransform;
    
    [Space]
    [Tooltip("상자 크기 변경 시간 조절")]
    [SerializeField, Range(0.1f, 2f)] private float doScaleDuration;
    [Tooltip("상자 움직임 시간 조절")]
    [SerializeField, Range(0.1f, 2f)] private float doMoveYDuration;
    [Tooltip("상자 흔들기 시간 조절")]
    [SerializeField, Range(0.1f, 2f)] private float doShakeRotationDuration;

    private void Awake()
    {
        rectTransform = transform as RectTransform;
        gameObject.SetActive(false);
    }

    public void AppearGiftBox()
    {
        // 스케일 연출
        gameObject.SetActive(true);
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(Vector3.one, doScaleDuration);

        // 등장 연출
        var originPosY = rectTransform.transform.position.y;
        rectTransform.transform.position = new Vector2(rectTransform.transform.position.x,
            rectTransform.transform.position.y + rectTransform.transform.position.y / 2f);
        rectTransform.DOMoveY(originPosY, doMoveYDuration);

        // 흔들기 연출
        rectTransform.DOShakeRotation(doShakeRotationDuration);
    }
}
