using System.Collections.Generic;
using UnityEngine;

public class ResetHouseBtn : MonoBehaviour
{
    private ItemContainer _itemContainer;

    private void Start()
    {
        _itemContainer = FindObjectOfType<ItemContainer>();
    }

    public void ClearAllFurniture()
    {
        if (_itemContainer.transform.childCount > 0)
        {
            List<Item> _furniture = new List<Item>();

            for (int i = 0; i < _itemContainer.transform.childCount; i++)
            {
                if (_itemContainer.transform.GetChild(i).TryGetComponent(out Item childItem))
                    _furniture.Add(childItem);
            }

            foreach (var child in _furniture)
            {
                child.TryGetComponent(out ItemDestroyer destroyer);
                destroyer.DestroyItem(child);
            }
        }
    }

    public void ClearAllPlatings()
    {
        List<PlatingAbleSurface> _surfaces = new List<PlatingAbleSurface>(FindObjectsOfType<PlatingAbleSurface>());

        foreach (var surface in _surfaces)
            surface.ClearPlatings();
    }
}