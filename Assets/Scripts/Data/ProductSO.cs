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
    
    public string Id => id;
    public ProductGrade Grade => grade;
    public string Company => company;
    public string ProductName => productName;
    public int Price => price;
}
