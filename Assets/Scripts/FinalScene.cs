using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _wallpaper;
    [SerializeField] private Canvas _canvas;

    private MainProgram _houseWindow;
    private House _house;
    private ItemContainer _container;
    private Background _houseBg;

    private void Awake()
    {
        _houseWindow = FindObjectOfType<MainProgram>();

        _house = _houseWindow.GetComponentInChildren<House>();

        _container = _houseWindow.GetComponentInChildren<ItemContainer>();

        if (_container.TryGetComponent(out MainProgramChild childScript))
            Destroy(childScript);

        _houseBg = _houseWindow.GetComponentInChildren<Background>();

        if (_houseBg.TryGetComponent(out Image image) && image.sprite != null)
            _wallpaper.sprite = image.sprite;
    }

    private void Start()
    {
        _house.transform.SetParent(_canvas.transform);
        _container.transform.SetParent(_canvas.transform);

        HouseCanvas canvas = FindObjectOfType<HouseCanvas>();

        if (canvas)
            Destroy(canvas.gameObject);
    }
}