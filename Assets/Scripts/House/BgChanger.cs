using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BgChanger : MonoBehaviour
{
    [SerializeField] private Image _bg;
    [SerializeField] private Sprite _image;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ChangeBackground);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ChangeBackground);
    }

    private void ChangeBackground()
    {
        _bg.color = Color.white;
        _bg.sprite = _image;
    }
}