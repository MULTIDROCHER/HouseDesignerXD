using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class ItemMovement : MonoBehaviour
{
    private Item _item;

    private void Awake()
    {
        _item = GetComponent<Item>();
    }

    private void OnMouseDrag()
    {
        transform.position = PointerController.MousePosition;
    }
}