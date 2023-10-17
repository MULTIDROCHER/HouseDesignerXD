public class FloorPlating : Plating
{
    protected override bool IsCompatible(PlatingAbleSurface surface)
    {
        return surface.TryGetComponent(out FloorSurface floor);
    }
}