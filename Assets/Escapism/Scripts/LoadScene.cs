using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public int sceneBuildIndex;

    public void Load()
    {
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public void LoadAsync()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneBuildIndex);
        while (!load.isDone)
            yield return null;
    }
}
