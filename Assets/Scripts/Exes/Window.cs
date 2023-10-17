using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Window : MonoBehaviour
{
    private float _delay = 10f;
    private WaitForSeconds _lifeTime;

    public UnityAction WindowClosed;

    private void Awake()
    {
        _lifeTime = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        StartCoroutine(DisableAfterDelay());
    }

    private IEnumerator DisableAfterDelay()
    {
        yield return _lifeTime;

        gameObject.SetActive(false);
        WindowClosed?.Invoke();
    }

    private void OnDisable()
    {
        WindowClosed?.Invoke();
        StopCoroutine(DisableAfterDelay());
    }
}