using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class DontDestroyCanvases : MonoBehaviour
{
    private int _amount = 3;
    private Canvas _canvas;

    private void Awake()
    {
        DontDestroyCanvases[] existingInstances = FindObjectsOfType<DontDestroyCanvases>();
        _canvas = GetComponent<Canvas>();

        if (existingInstances.Length > _amount)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);

        _canvas.worldCamera = Camera.main;
    }
}