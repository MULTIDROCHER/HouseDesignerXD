using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider2D))]
public class AutoClosingWindow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Collider2D _collider;
    private bool _pointerEnter;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        _collider.enabled = true;
    }

    private void OnDisable()
    {
        _collider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) == false && _pointerEnter == false)
            CloseWindow();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _pointerEnter = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _pointerEnter = false;
    }

    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}