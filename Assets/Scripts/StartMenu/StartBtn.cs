public class StartBtn : MenuBtn
{
    protected override void OnButtonClick()
    {
        SceneLoader.LoadScene(1);
    }
}