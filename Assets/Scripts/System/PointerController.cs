using UnityEngine;

public class PointerController : MonoBehaviour
{
    [SerializeField] private Texture2D _clickCursor;
    [SerializeField] private Texture2D _defaultCursor;

    public static Vector3 MousePosition;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        SetCursor(_defaultCursor);
    }

    private void Update()
    {
        MousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        MousePosition.z = 0;

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            SetCursor(_clickCursor);

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            SetCursor(_defaultCursor);
    }

    private void SetCursor(Texture2D cursor)
    {
        Cursor.SetCursor(cursor, new Vector2(40, 30), CursorMode.Auto);
    }
}