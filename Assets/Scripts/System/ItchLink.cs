using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ItchLink : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private TextMeshProUGUI _link;
    private float _outlineWidth = 0.3f;

    private void Start()
    {
        _link = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _link.outlineWidth += _outlineWidth;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _link.outlineWidth -= _outlineWidth;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.OpenURL("https://fucinkarbur.itch.io");
    }
}