using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlatingSpawner : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private PlatingTemplate _template;
    [SerializeField] private Plating _plating;

    private PlatingContainer _container;
    private PlatingTemplate _spawned;
    private Sprite _sprite;

    public UnityAction TemplateDropped;

    private Vector3 _mousePos => PointerController.MousePosition;
    public Plating Plating => _plating;

    private void Start()
    {
        _sprite = GetComponent<Image>().sprite;
        _container = FindObjectOfType<PlatingContainer>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _spawned = Instantiate(_template, _mousePos, Quaternion.identity, transform);

        if (_spawned.TryGetComponent(out Image image))
            image.sprite = _sprite;

        _spawned.transform.SetParent(_container.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _spawned.transform.position = _mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        TemplateDropped?.Invoke();
    }
}