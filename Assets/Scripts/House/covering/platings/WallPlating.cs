public class WallPlating : Plating
{
    protected override bool IsCompatible(PlatingAbleSurface surface)
    {
        return surface.TryGetComponent(out WallSurface wall);
    }
}