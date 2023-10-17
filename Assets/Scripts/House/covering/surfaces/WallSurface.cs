public class WallSurface : PlatingAbleSurface
{
    protected override bool IsCompatible(Plating plating)
    {
        return plating.TryGetComponent(out WallPlating wall);
    }
}