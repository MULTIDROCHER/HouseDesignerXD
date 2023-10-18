using UnityEngine;

public class MainProgramChild : MonoBehaviour
{
    private MainProgram _mainProgram;

    private void Awake()
    {
        _mainProgram = FindObjectOfType<MainProgram>();
    }

    private void OnEnable()
    {
        _mainProgram.Work += OnProgramOpen;
        _mainProgram.StopWork += OnProgramClose;
    }

    private void OnDisable()
    {
        _mainProgram.StopWork -= OnProgramClose;
    }

    private void OnDestroy()
    {
        gameObject.SetActive(true);
        _mainProgram.Work -= OnProgramOpen;
    }

    private void OnProgramOpen()
    {
        if (TryGetComponent(out Window window) == false)
            gameObject.SetActive(true);
    }

    private void OnProgramClose()
    {
        gameObject.SetActive(false);
    }
}