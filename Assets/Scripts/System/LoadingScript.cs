using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Image _status;

    private int _sceneIndex;

    public void Loading(int sceneIndex)
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;

        _loadingScreen.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(sceneIndex);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            _status.fillAmount = loadAsync.progress;

            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(.5f);
                loadAsync.allowSceneActivation = true;
            }

            yield return null;
        }

        _loadingScreen.SetActive(false);
        StopCoroutine(LoadAsync(sceneIndex));
    }
}