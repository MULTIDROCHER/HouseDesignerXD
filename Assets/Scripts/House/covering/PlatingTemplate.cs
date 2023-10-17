using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PlatingTemplate : MonoBehaviour
{
    private Image _image;
    private PlatingSpawner _spawner;
    private Plating _plating;
    private PlatingAbleSurface _surface;

    public Plating Plating => _plating;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _spawner = GetComponentInParent<PlatingSpawner>();
        _plating = _spawner.Plating;
    }

    private void OnEnable()
    {
        _spawner.TemplateDropped += OnTemplateDroped;
    }

    private void OnDisable()
    {
        _spawner.TemplateDropped -= OnTemplateDroped;
    }

    private void OnMouseDrag()
    {
        transform.position = PointerController.MousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out PlatingAbleSurface surface))
            SetSurface(surface);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out PlatingAbleSurface surface) && surface == _surface)
            SetSurface(null);
    }

    private void OnTemplateDroped()
    {
        TrySpawnPlating();
    }

    public void TrySpawnPlating()
    {
        if (_surface != null && _plating.CanBePlaced)
        {
            _surface.ClearPlatings();
            Instantiate(_plating, _surface.transform);

            SFXManager _sfx = FindObjectOfType<SFXManager>();

            if (_sfx != null)
                _sfx.CoverPlating();
        }

        Destroy(gameObject);
    }

    private void SetSurface(PlatingAbleSurface surface)
    {
        _surface = surface;
        _plating.GetSurface(surface);
    }
}