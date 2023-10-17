using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class PlatingAbleSurface : MonoBehaviour
{
    [SerializeField] private Material _outline;

    private Image _image;
    private Plating _plating;

    private void Start()
    {
        gameObject.TryGetComponent(out _image);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        MakeOutline(other, true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        MakeOutline(other, false);
    }

    public void ClearPlatings()
    {
        if (transform.childCount != 0)
        {
            List<Plating> platings = new List<Plating>(transform.GetComponentsInChildren<Plating>());

            foreach (var plating in platings)
                Destroy(plating.gameObject);
        }
    }

    protected abstract bool IsCompatible(Plating plating);

    private void MakeOutline(Collider2D collider, bool enabled)
    {
        collider.TryGetComponent(out PlatingTemplate template);

        if (template != null)
        {
            _plating = template.Plating;

            if (IsCompatible(_plating))
                EnableOutline(enabled);
        }
    }

    private void EnableOutline(bool enabled)
    {
        if (_image != null)
            _image.material = enabled ? _outline : null;
    }
}