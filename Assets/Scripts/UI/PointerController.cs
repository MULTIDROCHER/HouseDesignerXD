using UnityEngine;

public class PointerController : MonoBehaviour
{
    public static Vector3 MousePosition;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = 0;
    }
}