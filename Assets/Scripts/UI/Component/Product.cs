using DataDeclaration;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Product : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Image gradeIcon;
    [SerializeField] private TextMeshProUGUI gradeText;
    [SerializeField] private TextMeshProUGUI company;
    [SerializeField] private TextMeshProUGUI productName;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private Image maskImage;
    [SerializeField] private Image maskColor;
    
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private CanvasGroup maskCanvasGroup;
    
    public CanvasGroup MaskCanvasGroup => maskCanvasGroup;

    public void SetUp(ProductSO product)
    {
        Sprite productImage = Resources.Load<Sprite>($"Sprites/{product.Id}");
        image.sprite = productImage;
        gradeIcon.color = product.GradeColor;
        gradeText.text = product.Grade.ToString();
        company.text = product.Company;
        productName.text = product.ProductName;
        price.text = $"{product.Price:N0}원";

        maskImage.sprite = productImage;
        if (product.Grade >= ProductGrade.S)
        {
            maskColor.color = product.GradeColor;
        }
        
        canvasGroup.alpha = 0f;
    }

    public void AppearEffect()
    {
        Sequence sequence = DOTween.Sequence();
        float originY = gameObject.transform.position.y;
        var originScale = gameObject.transform.localScale;
        sequence.Append(gameObject.transform.DOMoveY(originY + 500f, 1f));
        sequence.Join(gameObject.transform.DOScale(originScale * 1.2f, 1.5f));
        sequence.Append(gameObject.transform.DOMoveY(originY + 300f, 1f));
        sequence.Join(gameObject.transform.DOScale(originScale, 0.5f));
        sequence.Append(canvasGroup.DOFade(1, 1f));
        sequence.AppendCallback(() =>
        {
            var @void = UIManager.Instance.Open<PopupReceiveProduct>();
        });
    }
}
