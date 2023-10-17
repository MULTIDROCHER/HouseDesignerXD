using UnityEngine.SceneManagement;

public class StartBtn : MenuBtn
{
    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}