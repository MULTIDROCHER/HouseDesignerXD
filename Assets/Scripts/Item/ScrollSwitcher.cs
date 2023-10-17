using UnityEngine;
using UnityEngine.UI;

public class ScrollSwitcher : MonoBehaviour
{
    [SerializeField] ScrollRect _scrollRect;

    protected void TurnOnScrolling()
    {
        _scrollRect.vertical = true;
    }

    protected void TurnOffScrolling()
    {
        _scrollRect.vertical = false;
    }
}