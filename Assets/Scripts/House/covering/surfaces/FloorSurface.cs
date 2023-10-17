public class FloorSurface : PlatingAbleSurface
{
    protected override bool IsCompatible(Plating plating)
    {
        return plating.TryGetComponent(out FloorPlating floor);
    }
}