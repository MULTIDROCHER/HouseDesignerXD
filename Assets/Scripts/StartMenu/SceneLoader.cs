using UnityEngine;
using System.Linq;

public class SceneLoader : MonoBehaviour
{
    public static void LoadScene(int sceneIndex)
    {
        SceneLoader sceneLoader = new SceneLoader();
        var loadingScreen = sceneLoader.FindLoadingScreen();

        if (loadingScreen != null)
            loadingScreen.Loading(sceneIndex);
    }

    private LoadingScreen FindLoadingScreen()
    {
        LoadingScreen[] objects = Resources.FindObjectsOfTypeAll<LoadingScreen>();

        LoadingScreen loadingScreen = objects.FirstOrDefault(screen => !screen.gameObject.activeSelf);

        return loadingScreen;
    }
}