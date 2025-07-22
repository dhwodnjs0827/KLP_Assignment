using DG.Tweening; // 반드시 추가할 것
using UnityEngine;
using UnityEngine.UI;

public class TestUIFade : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public RectTransform panel;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            FadeIn();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            FadeOut();
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            MovePanel();
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            ScaleIn();
        }
    }

    public void FadeIn()
    {
        canvasGroup.DOFade(1f, 0.5f); // 0.5초에 걸쳐 투명도 1로
    }

    public void FadeOut()
    {
        canvasGroup.DOFade(0f, 0.5f); // 0.5초에 걸쳐 투명도 0으로
    }
    
    public void MovePanel()
    {
        panel.DOAnchorPos(new Vector2(0, 0), 0.5f).SetEase(Ease.OutBack);
    }
    
    public void ScaleIn()
    {
        panel.localScale = Vector3.zero;
        panel.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }
}