using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Item : MonoBehaviour
{
    private Image _image;

    public UnityAction<Item> DestroyItem;
    public UnityAction<Item> ItemDroped;

    private void Awake()
    {
        _image = GetComponent<Image>();
        Debug.Log(gameObject.transform.position + "item");
    }

    private void OnMouseOver()
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