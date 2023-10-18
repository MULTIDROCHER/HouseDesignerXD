using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Item))]
public class ItemMovement : MonoBehaviour, IDragHandler
{
    private Item _item;

    private void Awake()
    {
        _item = GetComponent<Item>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = PointerController.MousePosition;
    }
}