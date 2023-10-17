using UnityEngine;
using System.Collections.Generic;

public class ItemContainer : MonoBehaviour
{
    public static ItemContainer Instance;
    private int _childCount;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}