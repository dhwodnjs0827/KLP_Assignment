using System.Collections.Generic;
using DataDeclaration;
using UnityEngine;
using UnityEngine.UI;

public class PopupProductResult : PopupUI
{
    [SerializeField] private Product product;
    [SerializeField] private Image gradeColor;
    [SerializeField] private CanvasGroup canvasGroup;

    private ProductSO data;
    private Dictionary<ProductGrade, Color> gradeColorDict;
    
    public Product Product => product;

    private void Awake()
    {
        Init();
        data = GameManager.Instance.GetRandomProduct();
    }

    private void Start()
    {
        Open();
    }

    private void Init()
    {
        gradeColorDict = new Dictionary<ProductGrade, Color>
        {
            { ProductGrade.B, Color.blue },
            { ProductGrade.A, Color.magenta },
            { ProductGrade.S, Color.yellow },
            { ProductGrade.SV, Color.red }
        };

        canvasGroup.alpha = 0;
    }

    protected override void Open()
    {
        product.SetUp(data);
        gradeColor.color = gradeColorDict[data.Grade];
    }

    protected override void Close()
    {
    }

    public void FadeEffect(float deltaY)
    {
        float alpha = Mathf.InverseLerp(0f, 930f, deltaY);
        canvasGroup.alpha = alpha;
        if (deltaY >= 500f)
        {
            float maskAlpha = Mathf.InverseLerp(930f, 500f, deltaY);
            product.MaskCanvasGroup.alpha = maskAlpha;
        }
        else
        {
            product.MaskCanvasGroup.alpha = 1f;
        }
    }
}
