using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void Load(SceneType scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public static void LoadAsync(SceneType scene)
    {
        SceneManager.LoadSceneAsync(scene.ToString());
    }
}

