using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class ItemSpawner : ScrollSwitcher, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Item _item;

    private Image _image;
    private Item _spawned;
    private ItemContainer _container;

    private Vector3 _mousePos => PointerController.MousePosition;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
        _container = FindAnyObjectByType<ItemContainer>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("work");
        _spawned = Instantiate(_item, _mousePos, Quaternion.identity, _container.transform);
        
        Debug.Log(_spawned.GetComponent<RectTransform>().position);

        _spawned.SetImage(_image.sprite);
        TurnOffScrolling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_spawned != null)
            _spawned.transform.position = _mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_spawned != null)
            _spawned.ItemDroped?.Invoke(_spawned);

        Vector3 pos = _spawned.transform.position;
        pos.z = 0;
        _spawned.GetComponent<RectTransform>().position = pos;

        TurnOnScrolling();
    }
}