using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExePool : MonoBehaviour
{
    private List<Exe> _pool = new List<Exe>();

    protected void Initialize(List<Exe> exes)
    {
        foreach (var exe in exes)
        {
            exe.gameObject.SetActive(false);
            _pool.Add(exe);
        }
    }

    protected bool TryGetExe(out Exe result)
    {
        var eligibleExes = _pool.FindAll(exe => exe.gameObject.activeSelf == false && exe.IsOpened == false).ToList();

        if (eligibleExes.Count > 0)
        {
            int randomIndex = Random.Range(0, eligibleExes.Count);
            result = eligibleExes[randomIndex];
            return true;
        }

        result = null;
        return false;
    }

    protected void Reset()
    {
        foreach (var exe in _pool)
        {
            exe.gameObject.SetActive(false);
            exe.Reset();
        }
    }
}