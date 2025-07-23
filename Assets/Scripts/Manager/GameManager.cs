using System.Collections.Generic;
using DataDeclaration;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoSingleton<GameManager>
{
    private Dictionary<ProductGrade,List<ProductSO>> productDict;

    protected override void Awake()
    {
        base.Awake();
        InitProductData();
    }

    private void Start()
    {
        UIManager.Instance.Open<PopupBoxCheck>();
    }

    private void InitProductData()
    {
        productDict = new Dictionary<ProductGrade, List<ProductSO>>();
        var products = Resources.LoadAll<ProductSO>("Data");
        foreach (var product in products)
        {
            if (!productDict.ContainsKey(product.Grade))
            {
                List<ProductSO> list = new List<ProductSO>();
                productDict.Add(product.Grade, list);
            }
            else
            {
                productDict[product.Grade].Add(product);
            }
        }
    }

    /// <summary>
    /// 확률에 의해 랜덤 상품 뽑기
    /// </summary>
    public ProductSO GetRandomProduct()
    {
        ProductGrade grade;
        int randomValue = Random.Range(0, 100);
        switch (randomValue)
        {
            case < 50:
                grade = ProductGrade.B;
                break;
            case < 90:
                grade = ProductGrade.A;
                break;
            case < 97:
                grade = ProductGrade.S;
                break;
            default:
                grade = ProductGrade.SV;
                break;
        }
        List<ProductSO> list = productDict[grade];
        ProductSO randomProduct = list[Random.Range(0, list.Count)];
        return randomProduct;
    }
}
