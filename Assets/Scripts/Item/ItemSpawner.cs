using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class ItemSpawner : ScrollSwitcher, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Item _item;

    private Image _image;
    private Item _spawned;
    private Transform _itemContainer;

    private Vector3 _mousePos => PointerController.MousePosition;

    private void OnEnable()
    {
        _image = GetComponent<Image>();
        _itemContainer = FindObjectOfType<ItemContainer>().transform;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_itemContainer != null)
        {
            _spawned = Instantiate(_item, _mousePos, Quaternion.identity, _itemContainer);
            _spawned.SetImage(_image.sprite);
            TurnOffScrolling();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_spawned != null)
            _spawned.transform.position = _mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_spawned != null)
        {
            SetZPosition(_spawned);
            _spawned.ItemDroped?.Invoke(_spawned);
        }

        TurnOnScrolling();
    }

    private void SetZPosition(Item item)
    {
        var rectTransform = item.GetComponent<RectTransform>();
        var anchoredPos = rectTransform.anchoredPosition3D;
        anchoredPos.z = 0;
        
        item.GetComponent<RectTransform>().anchoredPosition3D = anchoredPos;
    }
}