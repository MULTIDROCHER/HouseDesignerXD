using UnityEngine;

public class ExitBtn : MenuBtn
{
    protected override void OnButtonClick()
    {
        Application.Quit();
    }
}