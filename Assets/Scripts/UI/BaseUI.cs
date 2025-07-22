using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    private Animator animator;
    
    public abstract void Open();
    public abstract void Close();
}
