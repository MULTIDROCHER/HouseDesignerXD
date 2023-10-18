public class PlayAgainBtn : MenuBtn
{
    protected override void OnButtonClick()
    {
        SceneLoader.LoadScene(1);
    }
}