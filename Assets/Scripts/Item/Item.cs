using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Item : MonoBehaviour,IPointerClickHandler
{
    private Image _image;

    public UnityAction<Item> DestroyItem;
    public UnityAction<Item> ItemDroped;

    private void Awake()
    {
        _image = GetComponent<Image>();
        Debug.Log(gameObject.transform.position + "item");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(1))
            DestroyItem?.Invoke(this);
    }

    public void SetImage(Sprite sprite)
    {
        _image.sprite = sprite;
        _image.SetNativeSize();
    }
}