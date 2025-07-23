using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Canvas canvas;

    public T Open<T>() where T: BaseUI
    {
        T uiPrefab = Resources.Load<T>($"UI/{typeof(T).Name}");
        T ui = Instantiate(uiPrefab, canvas.transform);
        ui.transform.position = new Vector2(Screen.width / 2f, Screen.height / 2f);
        return ui;
    }
}
