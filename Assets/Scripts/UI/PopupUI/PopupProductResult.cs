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
    
    public Product Product => product;

    private void Awake()
    {
        canvasGroup.alpha = 0;
        data = GameManager.Instance.GetRandomProduct();
    }

    private void Start()
    {
        Open();
    }

    protected override void Open()
    {
        product.SetUp(data);
        gradeColor.color = data.GradeColor;
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
            product.MaskCanvasGroup.ignoreParentGroups = true;
            product.MaskCanvasGroup.alpha = maskAlpha;
        }
        else
        {
            product.MaskCanvasGroup.ignoreParentGroups = false;
        }
    }
}
