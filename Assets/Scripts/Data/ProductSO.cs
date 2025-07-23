using System.Collections.Generic;
using DataDeclaration;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductSO", menuName = "Scriptable Objects/ProductSO")]
public class ProductSO : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private ProductGrade grade;
    [SerializeField] private string company;
    [SerializeField] private string productName;
    [SerializeField] private int price;
    
    private readonly Dictionary<ProductGrade, Color> gradeColorDict = new Dictionary<ProductGrade, Color>
    {
        { ProductGrade.B, Color.blue },
        { ProductGrade.A, Color.magenta },
        { ProductGrade.S, Color.yellow },
        { ProductGrade.SV, Color.red }
    };
    
    public string Id => id;
    public ProductGrade Grade => grade;
    public Color GradeColor => gradeColorDict[grade];
    public string Company => company;
    public string ProductName => productName;
    public int Price => price;
}
