using UnityEngine;

public class OptionsBtn : MenuBtn
{
    [SerializeField] private OptionsWindow _optionsWindow;

    protected override void OnButtonClick()
    {
        _optionsWindow.gameObject.SetActive(true);
    }
}