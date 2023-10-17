using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Outline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Material _outline;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetMaterial(_outline);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetMaterial(null);
    }

    private void SetMaterial(Material material)
    {
        _image.material = material;
    }
}