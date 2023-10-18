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
            else
            Debug.Log("fuc");
    }

    private LoadingScript FindLoadingScreen()
    {
        LoadingScript[] objects = Resources.FindObjectsOfTypeAll<LoadingScript>();

        LoadingScript loadingScreen = objects.FirstOrDefault(screen => !screen.gameObject.activeSelf);

        return loadingScreen;
    }
}