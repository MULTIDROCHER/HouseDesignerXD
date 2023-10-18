using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Exe : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Window _window;

    private bool _isOpened = false;

    public bool IsOpened => _isOpened;

    public UnityAction<Exe> WindowOpened;

    public void OnPointerClick(PointerEventData eventData)
    {
        _isOpened = true;
        _window.gameObject.SetActive(true);

        WindowOpened?.Invoke(this);
        _window.WindowClosed += OnWindowClosed;
    }

    public void Reset()
    {
        _isOpened = false;
    }

    private void OnWindowClosed()
    {
        _isOpened = false;
        _window.WindowClosed -= OnWindowClosed;
    }
}