using UnityEngine;
using UnityEngine.Events;

public class MainProgram : MonoBehaviour
{
    [SerializeField] private Window[] _childPrograms;

    public UnityAction Work;
    public UnityAction StopWork;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Work?.Invoke();
    }

    private void OnDisable()
    {
        StopWork?.Invoke();

        foreach (var window in _childPrograms)
        {
            if (window != null)
                window.gameObject.SetActive(false);
        }
    }
}