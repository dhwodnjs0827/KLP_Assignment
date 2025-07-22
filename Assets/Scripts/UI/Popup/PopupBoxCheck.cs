using System.Collections;
using DG.Tweening;
using UnityEngine;

public class PopupBoxCheck : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform giftBox;

    private void Awake()
    {
        rectTransform.transform.position = new Vector2(rectTransform.transform.position.x, -Screen.height / 2f);
        giftBox.gameObject.SetActive(false);
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        Open();
    }

    private void Open()
    {
        rectTransform.DOMoveY(Screen.height / 2f, 1f).OnComplete(AppearGiftBox);
    }

    private void AppearGiftBox()
    {
        giftBox.gameObject.SetActive(true);
        giftBox.localScale = Vector3.zero;
        giftBox.DOScale(Vector3.one, 1f);

        var originPosY = giftBox.transform.position.y;
        giftBox.transform.position = new Vector2(giftBox.transform.position.x,
            giftBox.transform.position.y + giftBox.transform.position.y / 2f);
        giftBox.DOMoveY(originPosY, 1f);

        giftBox.DOShakeRotation(1);
    }
}