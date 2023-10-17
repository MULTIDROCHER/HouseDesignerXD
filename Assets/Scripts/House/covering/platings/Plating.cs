using UnityEngine;

public abstract class Plating : MonoBehaviour
{
    private PlatingAbleSurface _surface;

    public bool CanBePlaced => IsCompatible(_surface);

    protected abstract bool IsCompatible(PlatingAbleSurface surface);

    public void GetSurface(PlatingAbleSurface surface)
    {
        _surface = surface;
    }
}