using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExeSpawner : ExePool
{
    [SerializeField] private MainProgram _program;
    [SerializeField] private List<Exe> _exes;
    [SerializeField] private Transform[] _spawnPoints;

    private float _activeTime = 5f;
    private float _spawnRate = 2f;

    private void OnEnable()
    {
        _program.Work += OnProgramWork;
        _program.StopWork += OnProgramClosed;
    }

    private void OnDisable()
    {
        _program.Work -= OnProgramWork;
        _program.StopWork -= OnProgramClosed;
    }

    private void OnProgramWork()
    {
        Initialize(_exes);
        StartCoroutine(SpawnExe());
    }

    private void OnProgramClosed()
    {
        Reset();
        StopAllCoroutines();
    }

    private IEnumerator SpawnExe()
    {
        while (_program.gameObject.activeSelf)
        {
            if (TryGetExe(out Exe exe))
            {
                SetExe(exe, GetPoint().position);
                StartCoroutine(DisableAfterDelay(exe));
                exe.WindowOpened += OnWindowOpen;
            }

            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private IEnumerator DisableAfterDelay(Exe exe)
    {
        yield return new WaitForSeconds(_activeTime);
        exe.gameObject.SetActive(false);
    }

    private Transform GetPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }

    private void SetExe(Exe exe, Vector3 position)
    {
        exe.gameObject.SetActive(true);
        exe.transform.position = position;
    }

    private void OnWindowOpen(Exe exe)
    {
        exe.gameObject.SetActive(false);
        exe.WindowOpened -= OnWindowOpen;
    }
}