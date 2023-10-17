using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public abstract class MenuBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _button;
    private Vector3 _defaultSize;
    private Vector3 _hoveredSize = new Vector2(0.2f, 0.2f);

    private void Awake()
    {
        _button = GetComponent<Button>();
        _defaultSize = transform.localScale;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    protected abstract void OnButtonClick();

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale += _hoveredSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = _defaultSize;
    }
}