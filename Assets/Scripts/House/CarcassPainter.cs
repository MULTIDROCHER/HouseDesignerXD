using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class CarcassPainter : MonoBehaviour
{
    [SerializeField] private CarcassPart _coloringZone;

    private Button _button;
    private Image _image;
    private Color _color;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _color = GetComponent<Image>().color;
        _image = _coloringZone.GetComponent<Image>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(PaintZone);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(PaintZone);
    }

    private void PaintZone()
    {
        _image.color = _color;
    }
}