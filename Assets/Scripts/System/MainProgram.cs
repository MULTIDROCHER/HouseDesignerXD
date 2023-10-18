using UnityEngine;
using UnityEngine.Events;

public class MainProgram : MonoBehaviour
{
    [SerializeField] private MainProgramChild[] _childPrograms;

    public UnityAction Work;
    public UnityAction StopWork;

    private void Start()
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

        foreach (var child in _childPrograms)
        {
            if (child != null)
                child.gameObject.SetActive(false);
        }
    }
}